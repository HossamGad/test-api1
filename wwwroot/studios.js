let studioButton = document.getElementById("studioButton");
studioButton.addEventListener('click', function () {

    fetch("/Api/StudiosApi").then(res => {
        res.json().then(
            data => {
                console.log(data);
                if (data.length > 0) {
                    var temp = "";
                    data.forEach((u) => {
                        temp += "<tr>";
                        temp += "<td>" + u.studioId + "</td>";
                        temp += "<td>" + u.name + "</td>";
                        temp += "<td>" + u.ort + "</td>";

                    })
                    document.getElementById("dataStudio").innerHTML = temp;
                }

            }
        )
    }
    )
});
var createstudio = document.getElementById("FormId").addEventListener('submit', post);

var nameInput = document.getElementById("name").value;
var ortInput = document.getElementById("ort").value;

function post(event) {
    event.preventDefault();

    fetch('https://localhost:44323/Api/StudiosApi', {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify({
            name: nameInput,
            ort: ortInput,
        })
    })
        .then((res) => console.log("res", res))
        .catch(err => console.log(JSON.stringify(err)));

    alert("Film skapad");
};

/*
var studioButton = document.getElementById("deleteStudioForm").addEventListener('submit', del);

function del(event) {
    event.preventDefault();

    var studioId = document.getElementById("DeleteStudio").value;

    alert("har kilckat");
    
    fetch(`https://localhost:44323/Api/StudiosApi/${studioId}`, {

    method: 'DELETE'

    });
};
*/

/*
document.getElementById("deleteStudioForm").addEventListener('submit', function () {

    alert("har kilckat");

    let userID = document.getElementById("DeleteStudio").value;



    let options = {

        method: "DELETE"

    }

    let headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }

    fetch.API(`https://localhost:44323/Api/StudiosApi/${userID}`, options, headers, function (err, data) {

        if (err) {

            resultDIV.innerHTML = err;

        } else {

            resultDIV.innerHTML = JSON.stringify(data);

        }

    });

})
*/




