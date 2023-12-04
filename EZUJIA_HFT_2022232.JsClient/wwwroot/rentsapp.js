let rents = [];
let carbrandidtoupdate = -1;
let connection = null;
getData();
setupSignalR();



function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:63234/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RentsCreated", (user, message) => {
        getData();
    });

    connection.on("RentsDeleted", (user, message) => {
        getData();
    });

    connection.on("RentsUpdated", (user, message) => {
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
    let resp = await fetch("http://localhost:63234/rent");
    let data = await resp.json();
    rents = data;
    display();
}

function display() {
    document.querySelector("#rentsarea").innerHTML = "";
    rents.forEach(t => {
        document.querySelector("#rentsarea").innerHTML +=
            "<tr><td>" + t.rentId + "</td><td>" + t.rentTime + "</td><td>" + t.ownerName + "</td><td>" + t.carsId + "</td><td>" +
            `<button type="button" onclick="remove(${t.rentId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.rentId})">Update</button>` + "</td ></tr > ";
    })

}

function showupdate(id) {
    document.querySelector("#renttimeupdate").value = rents.find(t => t['rentId'] == id)['rentTime'];
    document.querySelector("#ownernameupdate").value = rents.find(t => t['rentId'] == id)['ownerName'];
    document.querySelector("#carsidupdate").value = rents.find(t => t['rentId'] == id)['carsId'];
    document.querySelector("#updateformdiv").style.display = 'flex';
    carbrandidtoupdate = id;
}

function remove(id) {
    fetch('http://localhost:63234/rent/' + id, {
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
    let renttime = document.querySelector("#renttime").value;
    let ownername = document.querySelector("#ownername").value;
    let carsid = document.querySelector("#carsid").value;



    fetch('http://localhost:63234/rent', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentTime: renttime,
                ownerName: ownername,
                carsId: carsid


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
    let renttime = document.querySelector("#renttimeupdate").value;
    let ownername = document.querySelector("#ownernameupdate").value;
    let carsid = document.querySelector("#carsidupdate").value;



    fetch('http://localhost:63234/rent', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentId: carbrandidtoupdate,
                rentTime: renttime,
                ownerName: ownername,
                carsId: carsid


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


