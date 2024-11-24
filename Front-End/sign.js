
function haha(){
    let msg = document.getElementById("msg");
    msg.style.color = "#FF0000"
}

function getLoginInfo(email, pass) {
    fetch('https://localhost:7096/api/Users/Login/' + email + '/' + pass,
        { method: 'GET' })
        .then(function (res) {
            if (res.ok) return res.json()
            else haha();
        }).then((data) => {
            if (data == "") haha();
            else {
                let name = data.UserName;
                console.log(name);

                localStorage.setItem("userToken", name);
                localStorage.setItem("emailToken", email);
                localStorage.setItem("idToken", data.UserID)
                // location.reload();

                window.location.href='home.html'
                
            }
        });
}

function logout() {
    localStorage.removeItem("userToken");
    localStorage.removeItem("emailToken");
    localStorage.removeItem("idToken")
    location.reload();
}

document.querySelector("#sign-button").addEventListener("click", function() {
    const userEmail = document.getElementById("email").value;
    const userPass = document.getElementById("pass").value;
    getLoginInfo(encodeURIComponent(userEmail), encodeURIComponent(userPass));
});