function invalidlogin() {
    console.log("Scam")
    document.getElementById("email").style.borderColor = "red";
    document.getElementById("pass").style.borderColor = "red";
}

function getLoginInfo(email, pass) {
    fetch('https://localhost:7096/api/Users/Login/' + email + '/' + pass,
        { method: 'GET' })
        .then(function (res) {
            if (res.ok) return res.json()
            else throw new Error('Response failed');
        }).then((data) => {
            if (data == "") invalidlogin();
            else {
                let name = data.UserName;
                console.log(name);
                if (!userToken) {
                    localStorage.setItem("userToken", name);
                    localStorage.setItem("emailToken", email);
                    localStorage.setItem("idToken", data.UserID)
                    location.reload();
                }
                else invalidlogin();
            }
        });
}

function logout() {
    localStorage.removeItem("userToken");
    localStorage.removeItem("emailToken");
    localStorage.removeItem("idToken")
    location.reload();
}