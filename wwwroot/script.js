
let movieButton = document.getElementById("movieButton");
movieButton.addEventListener('click', function() {


    fetch("https://localhost:44323/Api/MoviesApi").then(res => {
        res.json().then(
            data => {
                console.log(data);
                if (data.length > 0) {
                    var temp = "";
                    data.forEach((u) => {
                        temp += "<tr>";
                        temp += "<td>" + u.id + "</td>";
                        temp += "<td>" + u.title + "</td>";
                        temp += "<td>" + u.genre + "</td>";
                        temp += "<td>" + u.studioName + "</td>";
                        temp += "<td>" + u.reviews + "</td>";
                        temp += "<td>" + u.stock + "</td>";
                        temp += "<td>" + u.trivias + "</td>";


                    })
                    document.getElementById("data").innerHTML = temp;
                }

            }
        )
    }
    )
});


var createmovie = document.getElementById("formid").addEventListener('submit', post);

var titleInput = document.getElementById("title").value;
var genreInput = document.getElementById("genre").value;
var stockInput = document.getElementById("stock").value;
var studioNameInput = document.getElementById("studioName").value;

function post(event) {
    event.preventDefault();

    fetch('https://localhost:44323/Api/MoviesApi', {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify({
            title: titleInput,
            genre: genreInput,
            stock: stockInput,
            studioName: studioNameInput
        })
    })
    .then((res) => console.log("res", res))
    .catch(err => console.log(JSON.stringify(err)));

    alert("Film skapad");
};

