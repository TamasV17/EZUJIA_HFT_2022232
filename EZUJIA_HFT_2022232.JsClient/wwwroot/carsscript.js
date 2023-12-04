let car = [];
let carbrandidtoupdate = -1;
let connection = null;


getData();
setupSignalR();

//async function getData() {
//    await fetch("http://localhost:63234/cars")
//        .then(x => x.json())
//        .then(y => {
//            car = y;
//            display();

//        });
//}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:63234/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarsCreated", (user, message) => {
        getData();
    });

    connection.on("CarsDeleted", (user, message) => {
        getData();
    });

    connection.on("CarsUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData() {
    let resp = await fetch("http://localhost:63234/cars");
    let data = await resp.json();
    car = data;
    display();



}


function display() {
    document.querySelector("#carsarea").innerHTML = "";
    car.forEach(t => {
        document.querySelector("#carsarea").innerHTML +=
            "<tr><td>" + t.carsId + "</td><td>" + t.carBrandId + "</td><td>" + t.licensePlateNumber + "</td><td>" + t.year + "</td><td>" + t.type + "</td><td>" + t.performanceInHP+ "</td><td>" +
        `<button type="button" onclick="remove(${t.carsId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.carsId})">Update</button>` + "</td ></tr > ";
    })

}

function showupdate(id) {
    document.querySelector("#carbrandidupdate").value = car.find(t => t['carsId'] == id)['carBrandId'];
    document.querySelector("#licensePlateNumberupdate").value = car.find(t => t['carsId'] == id)['licensePlateNumber'];
    document.querySelector("#yearupdate").value = car.find(t => t['carsId'] == id)['year'];
    document.querySelector("#typeupdate").value = car.find(t => t['carsId'] == id)['type'];
    document.querySelector("#performanceInHPupdate").value = car.find(t => t['carsId'] == id)['performanceInHP'];

    document.querySelector("#updateformdiv").style.display = 'flex';
    carbrandidtoupdate = id;
}



function remove(id) {
    fetch('http://localhost:63234/cars/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {

            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function create() {
    //let names = document.querySelector("#carname").value;
    let carbrandid = document.querySelector("#carbrandid").value;
    let license = document.querySelector("#licensePlateNumber").value;
    let years = document.querySelector("#year").value;
    let types = document.querySelector("#type").value;
    let hp = document.querySelector("#performanceInHP").value;

    fetch('http://localhost:63234/cars', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {

                carBrandId: carbrandid,
                licensePlateNumber: license,
                year: years,
                type: types,
                performanceInHP: hp,

            }),
    })
        .then(response => response)
        .then(data => {

            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}


function update() {
    document.querySelector("#updateformdiv").style.display = 'none';
    //let names = document.querySelector("#carname").value;
    let carbrandid = document.querySelector("#carbrandidupdate").value;
    let license = document.querySelector("#licensePlateNumberupdate").value;
    let years = document.querySelector("#yearupdate").value;
    let types = document.querySelector("#typeupdate").value;
    let hp = document.querySelector("#performanceInHPupdate").value;

    fetch('http://localhost:63234/cars', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                carsId: carbrandidtoupdate,
                carBrandId: carbrandid,
                licensePlateNumber: license,
                year: years,
                type: types,
                performanceInHP: hp,







            }),
    })
        .then(response => response)
        .then(data => {

            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });


}
