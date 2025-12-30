<!-- <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Local Storage Demo</title>
</head>
<body>
    <h2>Local Storage Demo</h2>
    <label>Enter Name:</label><br><br>
    <input type="text" id="name"><br><br>
    <button onclick="saveData()">Save to Local Storage</button>
    <button onclick="getData()">get from Local Storage</button>
    <button onclick="removeData()">Remove Data</button>
    <button onclick="clearAll()">Clear All</button>
    <p id="result"></p>
    <script>
    function saveData(){
        let name =document.getElementById("name").value;
        localStorage.setItem("username",name);
        document.getElementById("result").innerHTML="data saved successfully!";
    }
    function getData(){
        let storedName =localStorage.getItem("username");
       
        document.getElementById("result").innerHTML="stored name:" + storedName;
    }
    function removeData(){
        localStorage.removeItem("username");
       
        document.getElementById("result").innerHTML="data removed";
    }
    function clearAll(){
        localStorage.clear();
       
        document.getElementById("result").innerHTML="All Local Storage Cleared";
    }
    
    </script>
 
</body>  
</html> -->
