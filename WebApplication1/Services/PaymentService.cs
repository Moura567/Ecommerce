using Newtonsoft.Json;
using System.Text;
using WebApplication1.Models;

public class PaymentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string ApiKey;
    private readonly string IntegrationId;

    public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        ApiKey = configuration["PayMob:ApiKey"];
        IntegrationId = configuration["PayMob:IntegrationId"];
    }

    public async Task<string> CreatePaymentOrder(Order order)
    {
        var client = _httpClientFactory.CreateClient();

        // الخطوة الأولى: الحصول على token
        var authResponse = await client.PostAsync(
            "https://accept.paymob.com/api/auth/tokens",
            new StringContent(JsonConvert.SerializeObject(new { api_key = ApiKey }), Encoding.UTF8, "application/json")
        );

        if (!authResponse.IsSuccessStatusCode) return null;

        var authResult = await authResponse.Content.ReadAsStringAsync();
        var authData = JsonConvert.DeserializeObject<dynamic>(authResult);
        var token = authData.token;

        var items = order.Items ?? new List<OrderItem>();

        var orderRequest = new
        {
            auth_token = token,
            delivery_needed = false,
            amount_cents = order.OrderPrice * 100,
            currency = "EGP",
            items = items.Select(i => new
            {
                name = i.ProductId,
                amount_cents = (int)(i.Price * 100),
                quantity = i.Quantity
            }).ToList()
        };


        var orderResponse = await client.PostAsync(
            "https://accept.paymob.com/api/ecommerce/orders",
            new StringContent(JsonConvert.SerializeObject(orderRequest), Encoding.UTF8, "application/json")
        );

        if (!orderResponse.IsSuccessStatusCode) return null;

        var orderResult = await orderResponse.Content.ReadAsStringAsync();
        var orderData = JsonConvert.DeserializeObject<dynamic>(orderResult);
        var paymobOrderId = orderData.id;

        // الخطوة الثالثة: إنشاء Payment Key
        var paymentKeyRequest = new
        {
            auth_token = token,
            amount_cents = order.OrderPrice * 100,
            expiration = 3600,
            order_id = paymobOrderId,
            billing_data = new
            {
                first_name = order.Email.Split('@')[0],
                last_name = order.Email.Split('@')[0],
                email = order.Email,
                phone_number = order.MobileNumber,
                apartment = "NA",
                floor = "NA",
                street = order.Address,
                building = "NA",
                shipping_method = "NA",
                city = "Cairo",
                country = "EG",
                postal_code = "NA"
            },
            currency = "EGP",
            integration_id = IntegrationId
        };

        var paymentKeyResponse = await client.PostAsync(
            "https://accept.paymob.com/api/acceptance/payment_keys",
            new StringContent(JsonConvert.SerializeObject(paymentKeyRequest), Encoding.UTF8, "application/json")
        );

        if (!paymentKeyResponse.IsSuccessStatusCode) return null;

        var paymentKeyResult = await paymentKeyResponse.Content.ReadAsStringAsync();
        var paymentKeyData = JsonConvert.DeserializeObject<dynamic>(paymentKeyResult);
        return paymentKeyData.token;
    }
}
