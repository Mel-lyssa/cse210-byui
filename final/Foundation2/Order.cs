using System.Net.Http.Headers;

public class Order
{
    protected List<Product> _products;

    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.CalculatePrice();
        }
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GeneratePackingLabel()
    {
        string label = "Packing Label: \n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        return label;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}