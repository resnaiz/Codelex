namespace VendingMachine.Test;

public class VendingMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    //INSERT COIN

    [Test]
    public void InsertCoin_ShouldInsertMoney_ValidMoneyIsInserted()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        Money money = new Money { Euros = 1, Cents = 0 };
        Money result = vendingMachine.InsertCoin(money);

        Assert.That(result.Euros, Is.EqualTo(money.Euros));
        Assert.That(result.Cents, Is.EqualTo(money.Cents));
    }

    [Test]
    public void InsertCoin_ShouldNotInsertMoney_InvalidMoneyNotInserted()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        Money money = new Money { Euros = 3, Cents = 0 };

        Assert.Throws<ExceptionInvalidCoin>(() => vendingMachine.InsertCoin(money));
    }

    [Test]
    public void InsertCoin_ShouldThrowException_WhenEmptyMoneyInserted()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        Money money = new Money { Euros = 0, Cents = 0 };

        Assert.Throws<ExceptionInvalidCoin>(() => vendingMachine.InsertCoin(money));
    }

    [Test]
    public void InsertCoin_ShouldInsertCoins_UpdateAmount()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        Money coin1 = new Money { Euros = 2, Cents = 50 };
        Money coin2 = new Money { Euros = 1, Cents = 20 };
        Money coin3 = new Money { Euros = 0, Cents = 10 };

        vendingMachine.InsertCoin(coin1);
        vendingMachine.InsertCoin(coin2);
        vendingMachine.InsertCoin(coin3);

        Assert.That(vendingMachine.Amount.Euros, Is.EqualTo(3));
        Assert.That(vendingMachine.Amount.Cents, Is.EqualTo(80));
    }

    [Test]
    public void InsertCoin_ShouldIncreaseAmountCorrectly_AfterPurchaseAmountUpdatedCorrectly()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Coke", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 }
        };

        VendingMachine vendingMachine = new VendingMachine("Codelex", products);

        Money coin = new Money { Euros = 2, Cents = 0 };
        vendingMachine.InsertCoin(coin);

        Assert.That(vendingMachine.Amount.Euros, Is.EqualTo(2));
        Assert.That(vendingMachine.Amount.Cents, Is.EqualTo(0));

        vendingMachine.Buy(0);

        Assert.That(vendingMachine.Amount.Euros, Is.EqualTo(0));
        Assert.That(vendingMachine.Amount.Cents, Is.EqualTo(50));
    }

    [Test]
    public void InsertCoin_ShouldThrowException_ThrowExceptionNegativeAmountInserted()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        Money money = new Money { Euros = -1, Cents = 50 };

        Assert.Throws<ExceptionInvalidCoin>(() => vendingMachine.InsertCoin(money));
    }

    //RETURN MONEY

    [Test]
    public void ReturnMoney_ShouldReturnMoney_ReturnedMoney()
    {
        VendingMachine vendingMachine = new VendingMachine("Codelex", new Product[] { });
        vendingMachine.InsertCoin(new Money { Euros = 2, Cents = 50 });
        vendingMachine.InsertCoin(new Money { Euros = 1, Cents = 10 });

        Money result = vendingMachine.ReturnMoney();

        Assert.That(result.Euros, Is.EqualTo(3));
        Assert.That(result.Cents, Is.EqualTo(60));
    }

    //BUY

    [Test]
    public void BuyTest_BuyProduct_ReturnProduct()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Pepsi", Price = new Money { Euros = 2, Cents = 20 }, Available = 1 }
        };

        IVendingMachine vendingMachine = new VendingMachine("Codelex", products);

        vendingMachine.InsertCoin(new Money { Euros = 2, Cents = 20 });

        vendingMachine.Buy(0);
    }

    [Test]
    public void BuyTest_GiveProductThatIsNoAvailable_ReturnedExceptionProductOutOfStock()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Pepsi", Price = new Money { Euros = 2, Cents = 20 }, Available = 0 }
        };

        IVendingMachine vendingMachine = new VendingMachine("Codelex", products);

        vendingMachine.InsertCoin(new Money { Euros = 2, Cents = 50 });

        Assert.Throws<ExceptionProductOutOfStock>(() => vendingMachine.Buy(0));
    }

    [Test]
    public void BuyTest_TryBuyProductWithLessMoneyYouNeed_ReturnedExceptionNotEnoughMoney()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Pepsi", Price = new Money { Euros = 2, Cents = 20 }, Available = 1 }
        };

        IVendingMachine vendingMachine = new VendingMachine("Codelex", products);

        vendingMachine.InsertCoin(new Money { Euros = 1, Cents = 10 });

        Assert.Throws<ExceptionNotEnoughMoney>(() => vendingMachine.Buy(0));
    }

    [Test]
    public void BuyTest_GiveInvalidId_ReturnedExceptionInvalidIdReceived()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Chocolate", Price = new Money { Euros = 2, Cents = 20 }, Available = 1 }
        };

        IVendingMachine vendingMachine = new VendingMachine("Codelex", products);

        vendingMachine.InsertCoin(new Money { Euros = 2, Cents = 50 });

        Assert.Throws<ExceptionInvalidIdReceived>(() => vendingMachine.Buy(3));
    }

    //ISVALIDCOIN

    [Test]
    public void IsValidCoin_GiveValidCoin_ReceivedMoney()
    {
        Money validCoin = new Money { Euros = 1, Cents = 50 };
        IVendingMachine vendingMachine = new VendingMachine("Codelex", new Product[0]);

        Assert.That(validCoin.Euros, Is.EqualTo(1));
        Assert.That(validCoin.Cents, Is.EqualTo(50));
    }

    [Test]
    public void IsValidCoin_GiveInvalidEuroCoin_ThrowExceptionInvalidEuroCoinInserted()
    {
        Money invalidCoin = new Money { Euros = 5, Cents = 20 };
        IVendingMachine vendingMachine = new VendingMachine("Codelex", new Product[0]);

        Assert.Throws<ExceptionInvalidCoin>(() => vendingMachine.InsertCoin(invalidCoin));
    }

    [Test]
    public void IsValidCoin_GiveInvalidCents_ThrowExceptionInvalidCentsInserted()
    {
        Money invalidCoin = new Money { Euros = 1, Cents = 35 };
        IVendingMachine vendingMachine = new VendingMachine("Codelex", new Product[0]);

        Assert.Throws<ExceptionInvalidCoin>(() => vendingMachine.InsertCoin(invalidCoin));
    }
    
    //manufacturer

    [Test]
    public void Constructor_ShouldSetManufacturerName_ManufacturerNameUpdated()
    {
        string manufacturerName = "Codelex";
        Product[] products = new Product[] { };
        VendingMachine vendingMachine = new VendingMachine(manufacturerName, products);

        Assert.That(vendingMachine.Manufacturer, Is.EqualTo(manufacturerName));
    }

    //HasProducts

    [Test]
    public void HasProducts_ShouldReturnTrue_ReturnedProductsAreAvailable()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 2 },
            new Product { Name = "Chips", Price = new Money { Euros = 1, Cents = 20 }, Available = 0 }
        };
        VendingMachine vendingMachine = new VendingMachine("Codelex", products);

        bool result = vendingMachine.HasProducts();

        Assert.That(result, Is.True);
    }

    [Test]
    public void HasProducts_ShouldThrowException_ThrowExceptionThereAreNoProductsAvailable()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Coke", Price = new Money { Euros = 1, Cents = 50 }, Available = 0 }
        };

        VendingMachine vendingMachine = new VendingMachine("Codelex", products);

        Assert.Throws<ExceptionProductOutOfStock>(() => vendingMachine.HasProducts());
    }


    //setgetproducts

    [Test]
    public void Products_ShouldSetAndGetProducts_ReturnedTrue()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 0 },
            new Product { Name = "Chips", Price = new Money { Euros = 1, Cents = 20 }, Available = 0 }
        };

        VendingMachine vendingMachine = new VendingMachine("Codelex", products);

        Product[] retrievedProducts = vendingMachine.Products;

        Assert.That(retrievedProducts, Is.EqualTo(products));
    }

    [Test]
    public void SetProducts_ShouldUpdateProductsArray_UpdatedProductArray()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 },
            new Product { Name = "Chips", Price = new Money { Euros = 1, Cents = 20 }, Available = 1 }
        };
        var vendingMachine = new VendingMachine("Codelex", products);

        Product[] newProducts = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 },
            new Product { Name = "Chips", Price = new Money { Euros = 1, Cents = 20 }, Available = 1 },
            new Product { Name = "Test", Price = new Money { Euros = 2, Cents = 20 }, Available = 1 }
        };

        vendingMachine.Products = newProducts;

        Assert.That(vendingMachine.Products, Is.EqualTo(newProducts));
    }

    //ValidatePrice

    [Test]
    public void ValidatePriceTest_BuyProductThatHasAnInvalidPrice_ReceivedExceptionProductHasInvalidPrice()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 100 }, Available = 1 },
            new Product { Name = "Soda", Price = new Money { Euros = -1, Cents = 50 }, Available = 1 },
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = -50 }, Available = 1 }
        };

        var vendingMachine = new VendingMachine("Codelex", products);

        Assert.Throws<ExceptionInvalidPriceFound>(
            () => vendingMachine.ValidatePrice(price: new Money { Euros = 1, Cents = 100 }));
        Assert.Throws<ExceptionInvalidPriceFound>(
            () => vendingMachine.ValidatePrice(price: new Money { Euros = -1, Cents = 50 }));
        Assert.Throws<ExceptionInvalidPriceFound>(
            () => vendingMachine.ValidatePrice(price: new Money { Euros = 1, Cents = -50 }));
    }

    [Test]
    public void ValidatePriceTest_ValidPrice_ReturnsTrue()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 }
        };

        var vendingMachine = new VendingMachine("Codelex", products);

        var result = vendingMachine.ValidatePrice(new Money { Euros = 1, Cents = 50 });

        Assert.That(result, Is.True);
    }

    //updateProduct

    [Test]
    public void UpdateProduct_ShouldUpdateProduct_WhenGivenValidInput()
    {
        Product[] _products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 }
        };

        var vendingMachine = new VendingMachine("Codelex", _products);
        var updatedProductName = "UpdatedProduct1";
        var updatedPrice = new Money { Euros = 2, Cents = 70 };
        var updatedAmount = 10;

        var result = vendingMachine.UpdateProduct(0, updatedProductName, updatedPrice, updatedAmount);

        Assert.IsTrue(result);
        Assert.That(vendingMachine.Products[0].Name, Is.EqualTo(updatedProductName));
        Assert.That(vendingMachine.Products[0].Price, Is.EqualTo(updatedPrice));
        Assert.That(vendingMachine.Products[0].Available, Is.EqualTo(updatedAmount));
    }

    [Test]
    public void UpdateProduct_ShouldThrowException_ThrowExceptionWhenGivenInvalidInput()
    {
        Product[] products = new Product[]
        {
            new Product { Name = "Soda", Price = new Money { Euros = 1, Cents = 50 }, Available = 1 }
        };

        var vendingMachine = new VendingMachine("Codelex", products);
        var updatedProductName = "UpdatedProduct1";
        var updatedPrice = new Money { Euros = 2, Cents = 70 };
        var updatedAmount = 10;

        TestDelegate updateMethod =
            () => vendingMachine.UpdateProduct(1, updatedProductName, updatedPrice, updatedAmount);

        Assert.Throws<ExceptionInvalidInputGiven>(updateMethod);
    }

    //AddProduct 

    [Test]
    public void AddProduct_ShouldAddProduct_ThrowExceptionWhenGivenValidInput()
    {
        Product[] products = new Product[10];
        var vendingMachine = new VendingMachine("Codelex", products);

        var productName = "Test Product";
        var price = new Money { Euros = 1, Cents = 50 };
        var productsCount = 5;

        var result = vendingMachine.AddProduct(productName, price, productsCount);

        Assert.IsTrue(result);
        Assert.That(vendingMachine.HasProducts, Is.True);
    }

    [Test]
    public void AddProduct_ShouldThrowException_ThrowExceptionWhenGivenInvalidInput()
    {
        Product[] products = new Product[10];
        var vendingMachine = new VendingMachine("Codelex", products);

        var productName = "";
        var price = new Money { Euros = -1, Cents = 50 };
        var productsCount = -5;

        Assert.Throws<ExceptionInvalidInputGivenAddProducts>(() =>
            vendingMachine.AddProduct(productName, price, productsCount));
    }

    [Test]
    public void AddProduct_ShouldThrowException_ThrowExceptionWhenGivenNullOrEmptyProductName()
    {
        Product[] products = new Product[10];
        var vendingMachine = new VendingMachine("Codelex", products);

        Money price = new Money { Euros = 1, Cents = 50 };
        var productsCount = 5;

        var nullProductName = "";
        Assert.Throws<ExceptionInvalidInputGivenAddProducts>(() =>
            vendingMachine.AddProduct(nullProductName, price, productsCount));

        var emptyProductName = " ";
        Assert.Throws<ExceptionInvalidInputGivenAddProducts>(() =>
            vendingMachine.AddProduct(emptyProductName, price, productsCount));
    }

    [Test]
    public void AddProduct_ShouldThrowException_ThrowExceptionWhenAddingToEmptyMachine()
    {
        Product[] products = new Product[0];
        var vendingMachine = new VendingMachine("Codelex", products);

        var productName = "Test Product";
        var price = new Money { Euros = 1, Cents = 50 };
        var productsCount = 5;

        Assert.Throws<ExceptionProductOutOfStock>(() => vendingMachine.AddProduct(productName, price, productsCount));
    }
}
    
