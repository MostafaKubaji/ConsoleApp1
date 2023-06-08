using System;

namespace AutoPartsStore
{
    class Program
    {
        static void Main(string[] args)
        {
            // إنشاء كائن من السياق لقاعدة البيانات
            using (var context = new AutoPartsStoreContext())
            {
                context.Database.EnsureCreated();
                // إنشاء كائنات المستودعات
                var carRepository = new CarRepository(context);
                var partRepository = new PartRepository(context);
                var supplierRepository = new SupplierRepository(context);
                var supper = new Supplier()
                {
                    Address = "121212",
                    Name = "sup1"
                };
                supplierRepository.AddSupplier(supper); 
                // إضافة سيارة
                var car = new Car
                {
                    Name = "Toyota Camry",
                    Year = 2022,
                    Gear = "Automatic",
                    Km = 0
                };

                carRepository.AddCar(car);

                // إضافة قطعة
                var part = new Part
                {
                    Name = "Engine Oil",
                    Quantity = 10,
                    Price = 29.99m,
                    SupplierId = 1 // نفترض أن المورد بالمعرف 1 موجود بالفعل
                };

                partRepository.AddPart(part);

                // إضافة مورد
                var supplier = new Supplier
                {
                    Name = "ABC Parts Supplier",
                    Address = "123 Main St"
                };

                supplierRepository.AddSupplier(supplier);

                Console.WriteLine("Car, part, and supplier added successfully.");
            }
        }
    }
}
