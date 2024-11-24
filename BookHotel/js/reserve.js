idToken = localStorage.getItem("idToken")
userToken = localStorage.getItem("userToken")
emailToken = localStorage.getItem("emailToken")

function getReserve(userID) {
    fetch('https://localhost:7096/Reservations/UserRsv/' + userID,
        { method: 'GET' })
        .then((res) => res.json())
        .then((data) => {
            if (data == []) {
                console.log("No result found")
            }
            else {
                data.ForEach(function (resv) {
                    console.log(resv)
                })
            }
        })
}

function newReserve(userID, roomID) {
    fetch('https://localhost:7096/Reservations/New/' + userID + '/' + roomID,
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then((res) => res.json())
        .then((data) => console.log(data))
}

getReserve(idToken)
newReserve(idToken, roomID)