// 1. Create / switch to database
use social_media

// 2. Create collection
db.data.insertMany([
  { user_id: 1, username: "alice", age: 22, country: "India", followers: 120, posts: 45 },
  { user_id: 2, username: "bob", age: 25, country: "USA", followers: 340, posts: 78 },
  { user_id: 3, username: "charlie", age: 21, country: "India", followers: 560, posts: 120 },
  { user_id: 4, username: "david", age: 28, country: "UK", followers: 90, posts: 30 },
  { user_id: 5, username: "emma", age: 24, country: "India", followers: 800, posts: 200 },
  { user_id: 6, username: "frank", age: 30, country: "USA", followers: 150, posts: 60 },
  { user_id: 7, username: "grace", age: 27, country: "Canada", followers: 410, posts: 95 },
  { user_id: 8, username: "harry", age: 23, country: "India", followers: 50, posts: 10 },
  { user_id: 9, username: "ivy", age: 26, country: "UK", followers: 670, posts: 150 },
  { user_id: 10, username: "jack", age: 29, country: "Canada", followers: 300, posts: 85 }
])

// 3. Aggregation examples

// Total users
db.data.aggregate([
  { $count: "total_users" }
])

// Average followers
db.data.aggregate([
  { $group: { _id: null, avg_followers: { $avg: "$followers" } } }
])

// Max followers
db.data.aggregate([
  { $group: { _id: null, max_followers: { $max: "$followers" } } }
])

// Total followers by country
db.data.aggregate([
  { $group: { _id: "$country", total_followers: { $sum: "$followers" } } }
])

// Average posts by country
db.data.aggregate([
  { $group: { _id: "$country", avg_posts: { $avg: "$posts" } } }
])
