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
