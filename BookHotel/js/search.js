function getHotelByName(name) {
    fetch('https://localhost:7096/Hotels/Name/' + name,
        { method: 'GET' })
        .then((res) => res.json())
        .then((data) => {
            if (data == []) {
                console.log("No result found")
            }
            else {
                data.forEach(function (hotel) {
                    console.log(hotel)
                })
            }
        })
}

function getHotelbyCity(city) {
    fetch('https://localhost:7096/Hotels/City/' + city,
        { method: 'GET' })
        .then((res) => res.json())
        .then((data) => {
            if (data == []) {
                console.log("No result found")
            }
            else {
                data.forEach(function (hotel) {
                    console.log(hotel)
                })
            }
        })
}