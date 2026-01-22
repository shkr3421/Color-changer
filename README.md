1. Static method to check strong password
Copy code
Python
class Validator:
    @staticmethod
    def is_strong(password):
        return (len(password) >= 8 and
                any(c.isupper() for c in password) and
                any(c.islower() for c in password) and
                any(c.isdigit() for c in password))

print(Validator.is_strong("Abc12345"))
2. Static method for temperature conversion
Copy code
Python
class Temperature:
    @staticmethod
    def c_to_f(c): return (c * 9/5) + 32

    @staticmethod
    def f_to_c(f): return (f - 32) * 5/9

print(Temperature.c_to_f(25))
print(Temperature.f_to_c(77))
3. Static method to check leap year
Copy code
Python
class Utility:
    @staticmethod
    def is_leap(year):
        return year % 400 == 0 or (year % 4 == 0 and year % 100 != 0)

print(Utility.is_leap(2024))
4. Static method to validate product code (ABC-1234)
Copy code
Python
import re

class Product:
    @staticmethod
    def validate(code):
        return bool(re.match(r"^[A-Z]{3}-\d{4}$", code))

print(Product.validate("ABC-1234"))
5. Reuse static method across classes
Copy code
Python
class MathUtil:
    @staticmethod
    def square(x): return x * x

class A:
    def show(self): print(MathUtil.square(4))

class B:
    def display(self): print(MathUtil.square(5))

A().show()
B().display()
6. Class method to count objects
Copy code
Python
class Student:
    count = 0

    def __init__(self):
        Student.count += 1

    @classmethod
    def total(cls):
        return cls.count

Student(); Student()
print(Student.total())
7. Class method as factory method
Copy code
Python
class User:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    @classmethod
    def from_dict(cls, data):
        return cls(data["name"], data["age"])

u = User.from_dict({"name": "Shashank", "age": 23})
print(u.name, u.age)
8. Shared interest rate using class method
Copy code
Python
class Bank:
    interest = 5

    @classmethod
    def update_rate(cls, rate):
        cls.interest = rate

Bank.update_rate(7)
print(Bank.interest)
9. Class method called from child class
Copy code
Python
class Parent:
    @classmethod
    def show(cls):
        print(cls.__name__)

class Child(Parent):
    pass

Child.show()
10. Class method resets class data
Copy code
Python
class Data:
    value = 100

    @classmethod
    def reset(cls):
        cls.value = 0

Data.reset()
print(Data.value)
11. Private method for interest calculation
Copy code
Python
class BankAccount:
    def __calculate_interest(self, balance):
        return balance * 0.05

    def get_interest(self, balance):
        return self.__calculate_interest(balance)

print(BankAccount().get_interest(1000))
12. Public method calling private validation
Copy code
Python
class User:
    def __validate(self, age):
        return age >= 18

    def register(self, age):
        return "Allowed" if self.__validate(age) else "Not Allowed"

print(User().register(20))
13. Private method not accessible directly
Copy code
Python
class Test:
    def __hidden(self):
        print("Hidden")

t = Test()
# t.__hidden()  # ERROR
14. Name mangling demo
Copy code
Python
class Demo:
    def __secret(self):
        print("Secret")

d = Demo()
d._Demo__secret()
15. Private method change doesn’t affect external code
Copy code
Python
class A:
    def __logic(self):
        return 10

    def result(self):
        return self.__logic()

print(A().result())
16. Instance method updates salary
Copy code
Python
class Employee:
    def __init__(self, salary):
        self.salary = salary

    def increment(self, amount):
        self.salary += amount

e = Employee(30000)
e.increment(5000)
print(e.salary)
17. Instance method modifies instance + class variable
Copy code
Python
class Counter:
    total = 0

    def __init__(self):
        self.count = 0

    def increment(self):
        self.count += 1
        Counter.total += 1

c = Counter()
c.increment()
print(c.count, Counter.total)
18. Error calling instance method without object
Copy code
Python
class A:
    def show(self):
        print("Hello")

# A.show()  # ERROR
19. Instance method returns calculated data
Copy code
Python
class Rectangle:
    def __init__(self, l, b):
        self.l = l
        self.b = b

    def area(self):
        return self.l * self.b

print(Rectangle(5, 4).area())
20. Override method and call parent using super
Copy code
Python
class Parent:
    def show(self):
        print("Parent")

class Child(Parent):
    def show(self):
        super().show()
        print("Child")

Child().show()
21. Multiple objects store different data
Copy code
Python
class Person:
    def __init__(self, name):
        self.name = name

p1 = Person("A")
p2 = Person("B")
print(p1.name, p2.name)
22. Class vs instance variables
Copy code
Python
class Sample:
    x = 10

    def __init__(self, y):
        self.y = y

a = Sample(5)
print(a.x, a.y)
23. Class without constructor
Copy code
Python
class Demo:
    pass

d = Demo()
d.name = "Shashank"
print(d.name)
24. Object reference assignment
Copy code
Python
class A:
    pass

x = A()
y = x
print(x is y)
25. Object deletion
Copy code
Python
class A:
    def __del__(self):
        print("Object deleted")

a = A()
del a
26. Single inheritance
Copy code
Python
class Parent:
    def show(self):
        print("Parent")

class Child(Parent):
    pass

Child().show()
27. Override parent method
Copy code
Python
class Parent:
    def greet(self):
        print("Hello")

class Child(Parent):
    def greet(self):
        print("Hi")

Child().greet()
28. Inheritance + overriding
Copy code
Python
class Animal:
    def sound(self):
        print("Sound")

class Dog(Animal):
    def sound(self):
        print("Bark")

Dog().sound()
29. super() in constructor
Copy code
Python
class Parent:
    def __init__(self):
        print("Parent init")

class Child(Parent):
    def __init__(self):
        super().__init__()
        print("Child init")

Child()
30. Extend functionality without modifying parent
Copy code
Python
class Calculator:
    def add(self, a, b):
        return a + b

class AdvancedCalculator(Calculator):
    def multiply(self, a, b):
        return a * b

c = AdvancedCalculator()
print(c.add(2, 3), c.multiply(2, 3))
