function changeName(userID, newName) {
    fetch('https://localhost:7096/api/Users/ChangeName/' + userID,
        {
            method: 'PUT',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newName)
        })
        .then((res) => res.json())
        .then((data) => {
            console.log(data);
        })
}