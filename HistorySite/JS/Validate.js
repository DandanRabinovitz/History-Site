function Validate() {

    var userName = document.getElementById("userName").value;
    var password = document.getElementById("password").value;
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var birthday = document.getElementById("birthday").value;
    var city = document.getElementById("city").value;
    var country = document.getElementById("country").value;
    console.log(password);
    if (userName == "" || password == "" || firstName == "" || lastName == "" || birthday == "" || city == "" || country == "") {
        alert("You must fill all fields");
        return false;
    }
    return true;
}

