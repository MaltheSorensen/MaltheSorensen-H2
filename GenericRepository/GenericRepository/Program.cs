
using GenericRepository;

Repository<Car> carRepo = new Repository<Car>();
Repository<Computer> computerRepo = new Repository<Computer>();
Repository<Employee> employeeRepo = new Repository<Employee>();
Repository<Phone> phoneRepo = new Repository<Phone>();

Car c1 = new Car("AB 12 345", 80000);
Car c2 = new Car("CD 34 456", 65000);
Car c3 = new Car("EF 56 567", 28000);

carRepo.Add(c1);
carRepo.Add(c2);
carRepo.Add(c3);

Employee e1 = new Employee("Allan", 1962);
Employee e2 = new Employee("Bente", 1975);
Employee e3 = new Employee("Carlo", 1973);

employeeRepo.Add(e1);
employeeRepo.Add(e2);
employeeRepo.Add(e3);

Computer comp1 = new Computer("123456", "PC1");
Computer comp2 = new Computer("234567", "PC1");

computerRepo.Add(comp1);
computerRepo.Add(comp2);

Phone p1 = new Phone("12345678", "Samsung");
Phone p2 = new Phone("87654321", "Iphone");

phoneRepo.Add(p1);
phoneRepo.Add(p2);

carRepo.printAll();
Console.WriteLine("Car Repository count: " + carRepo.Count);

employeeRepo.printAll();
Console.WriteLine("Employee Repository count: " +  employeeRepo.Count);

computerRepo.printAll();
Console.WriteLine("Computer repository count: " + computerRepo.Count);

phoneRepo.printAll();
Console.WriteLine("Phone Repository count: " +  phoneRepo.Count);
