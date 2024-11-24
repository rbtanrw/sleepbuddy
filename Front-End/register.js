function invalidlogin() {
    console.log("Scam")
    document.getElementById("email").style.borderColor = "red";
    document.getElementById("pass").style.borderColor = "red";
}

function registerInfo(name, email, pass) {
    fetch('https://localhost:7096/api/Users/Register/' + name + '/' + email + '/' + pass,
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(function (res) {
            if (res.ok) return res.json()
            else throw new Error("Response failed");
        }).then((data) => {
            let name = data.UserName;
            console.log(name);

            localStorage.setItem("userToken", name);
            localStorage.setItem("emailToken", email);
            localStorage.setItem("idToken", data.UserID)

            window.location.href='home.html'
        });
}

function logout() {
    localStorage.removeItem("userToken");
    localStorage.removeItem("emailToken");
    localStorage.removeItem("idToken")
    location.reload();
}

document.querySelector("#regist-button").addEventListener("click", function() {
    const userName = document.getElementById("name").value
    const userEmail = document.getElementById("email").value;
    const userPass = document.getElementById("pass").value;
    registerInfo(userName, encodeURIComponent(userEmail), encodeURIComponent(userPass))
});