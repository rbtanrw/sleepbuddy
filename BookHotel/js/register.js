function registerInfo(name, email, pass) {
    fetch('https://localhost:7096/api/Users/Login/' + name + '/${encodeURIComponent(email)}/${encodeURIComponent(password)}',
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
        });
}