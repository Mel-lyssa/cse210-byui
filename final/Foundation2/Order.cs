using System.Net.Http.Headers;

public class Order
{
    private List<Product> _products;

    private Customer _customer;

    public float CalculateTotalCost();

    public string GeneratePackingLaver();

    public string GenerateShippingLabel();
}