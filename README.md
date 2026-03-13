
<h2>Razor view</h2>
 
@{
        var Total = 500;
 
}
<p>The value of your account is:@Total</p>
<p>Today's Date and Time:@DateTime.Now</p>
@{
    var greeting = "Welcome to Razor view"; 
    var weekday = DateTime.Now.DayOfWeek;
    var greetingmesage = greeting + "Today is : " + weekday;
}
<p>@greetingmesage</p>
