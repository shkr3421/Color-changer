Below are clear, exam/interview-ready answers for MongoDB 👇


---

1. Insert Operations

Q1. Purpose of insertOne()?
→ Inserts one document into a collection.

Q2. Insert a single document

db.students.insertOne({ id: 1, name: "Shashank", dept: "CSE" })

Q3. What if collection does not exist?
→ MongoDB automatically creates the collection.

Q4. What is insertMany()? Difference from insertOne()?
→ Inserts multiple documents at once
→ insertOne() = single document
→ insertMany() = array of documents

Q5. If one document fails in insertMany()?
→ By default, stops at the error
→ Already inserted documents remain
→ Use { ordered: false } to continue inserting others


---

2. Update Operations

Q1. Difference between updateOne() and updateMany()?

updateOne() → updates first matched document only

updateMany() → updates all matched documents


Q2. Update only one document

db.students.updateOne(
  { id: 1 },
  { $set: { dept: "IT" } }
)

Q3. Update multiple documents

db.students.updateMany(
  { dept: "CSE" },
  { $set: { college: "CU" } }
)

Q4. If updateOne() matches multiple documents?
→ Only one (first match) is updated

Q5. Operator to update specific fields without replacing document?
→ $set


---

3. Add Date (Current Date)

Q1. Add current date while inserting

db.logs.insertOne({
  action: "login",
  createdAt: new Date()
})

Q2. MongoDB equivalent of SQL CURDATE()?
→ new Date() or $currentDate

Q3. Add current date to all existing documents

db.logs.updateMany(
  {},
  { $currentDate: { updatedAt: true } }
)

Q4. new Date() vs $currentDate

new Date()	$currentDate

Used during insert	Used during update
Client-side	Server-side
Fixed value	Always current



---

4. Delete Operations

Q1. deleteOne() vs deleteMany()

deleteOne() → deletes one document

deleteMany() → deletes multiple documents


Q2. Delete a single document

db.students.deleteOne({ id: 1 })

Q3. What if filter is {} in deleteMany()?
→ Deletes all documents, collection remains


---

5. Drop Operations

Q1. Drop a collection

db.students.drop()

Q2. Drop entire database

db.dropDatabase()

Q3. deleteMany({}) vs drop()

deleteMany({})	drop()

Deletes all documents	Deletes collection
Collection remains	Collection removed
Indexes remain	Indexes removed



---

If you want, I can give only commands, MCQ-style answers, or interview cheat-sheet format next.




Below are clean, practical MongoDB CRUD commands using MongoDB.
You can directly run these in MongoDB shell / online compiler.


---

1. InsertOne (Practical)

Insert a student

db.students.insertOne({
  name: "Shashank",
  course: "CSE",
  year: 2024
})

Insert an employee

db.employees.insertOne({
  name: "Rahul",
  role: "Developer",
  salary: 60000,
  joiningDate: new Date()
})

Insert a product

db.products.insertOne({
  name: "Laptop",
  price: 55000,
  category: "Electronics"
})


---

2. InsertMany (Practical)

Insert 5 users

db.users.insertMany([
  { name: "Ali", age: 22 },
  { name: "Riya", age: 24 },
  { name: "Aman", age: 23 },
  { name: "Neha", age: 21 },
  { name: "Karan", age: 25 }
])

Insert multiple products

db.products.insertMany([
  { name: "Phone", price: 20000, category: "Electronics" },
  { name: "Chair", price: 3000, category: "Furniture" },
  { name: "Table", price: 7000, category: "Furniture" }
])

Insert many orders

db.orders.insertMany([
  { orderId: 101, customerName: "Ali", totalAmount: 1500 },
  { orderId: 102, customerName: "Riya", totalAmount: 2500 },
  { orderId: 103, customerName: "Aman", totalAmount: 1800 }
])


---

3. UpdateOne (Practical)

Update salary of one employee

db.employees.updateOne(
  { name: "Rahul" },
  { $set: { salary: 70000 } }
)

Add status to one user

db.users.updateOne(
  { name: "Ali" },
  { $set: { status: "Active" } }
)

Change city of one customer

db.customers.updateOne(
  { name: "Riya" },
  { $set: { city: "Delhi" } }
)


---

4. UpdateMany (Practical)

Add updatedDate to all records

db.users.updateMany(
  {},
  { $currentDate: { updatedDate: true } }
)

Increase price of products in a category

db.products.updateMany(
  { category: "Electronics" },
  { $inc: { price: 2000 } }
)

Add country to all users

db.users.updateMany(
  {},
  { $set: { country: "India" } }
)


---

5. Add Date (Practical)

Insert document with current date

db.logs.insertOne({
  action: "login",
  date: new Date()
})

Add today’s date to all documents

db.logs.updateMany(
  {},
  { $currentDate: { todayDate: true } }
)

Convert numeric year to date

db.students.updateMany(
  { year: { $type: "number" } },
  [{ $set: { year: { $toDate: { $concat: [{ $toString: "$year" }, "-01-01"] } } } }]
)


---

6. DeleteOne (Practical)

Delete user named "Ali"

db.users.deleteOne({ name: "Ali" })

Delete one product by productId

db.products.deleteOne({ productId: 101 })


---

7. DeleteMany (Practical)

Delete users from a city

db.users.deleteMany({ city: "Delhi" })

Delete records where year < 2020

db.students.deleteMany({ year: { $lt: 2020 } })


---

8. Drop Operations (Practical)

Drop students collection

db.students.drop()

Drop current database

db.dropDatabase()


---

If you want, I can give this as a one-page cheat sheet, MCQ form, or only commands without headings.
