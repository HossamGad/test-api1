console.log("Hello World")

const localHost = "https://localhost:44361/api/";


//--------------------------------------------------
let login = document.getElementById("login");
let displayUser = document.getElementById("userName");



if (localStorage.getItem("userId") !== null) {
    showWelcomePage();
} else {
    showLoginPage();
}
//--------------------------------------------------


//Startstidan, login
function showLoginPage() {

    //Töm sidan
    login.innerHTML = "";
    displayUser.innerHTML = "Välkommen";
    document.getElementById("rentalButton").style.visibility = "hidden";
    document.getElementById("triviaButton").style.visibility = "hidden";
    document.getElementById("studioButton").style.visibility = "visible";



    //Inline-kodning lägger till två inputfält och en logga-in knapp
    login.insertAdjacentHTML("afterbegin", ' Name: <input class="login" id="loginUser" type="text"> Password: <input class="login" id="password" type="password"> <button class="loginbtn" id="loginbtn">Logga In</button>');

    let loginButton = document.getElementById("loginbtn");

    //lyssnar på ett knapptryck och börjar processa informationen som angavs
    loginButton.addEventListener("click", function () {
        let getUser = document.getElementById("loginUser").value;
        let getPass = document.getElementById("password").value;

        getDataAsync("filmstudio")
            .then(function (studios) {
                //jämför de angivna värdena med de som finns lagrade i jsondokumentet
                for (let i = 0; i < studios.length; i++) {
                    if (getUser == studios[i].name && getPass == studios[i].password) {
                        console.log("Login Success!!")

                        //sparar id:et (i det här fallet indexplatsen) i vårat localstorage
                        localStorage.setItem("userId", i)
                    }
                }

                //om inloggningen lyckades så visas välkomstsidan annars errorsidan
                if (localStorage.getItem("userId") !== null) {
                    showWelcomePage();

                } else {
                    showErrorPage();
                }
            });
    });
}

//Inloggningen lyckades inte
function showErrorPage() {
    login.insertAdjacentHTML("afterbegin", "<div>Något gick fel, har du glömt av ditt lösenord?</div><br>");
}

// Inloggning har lyckats
function showWelcomePage() {
    login.innerHTML = "";
    document.getElementById("rentalButton").style.visibility = "visible";
    document.getElementById("triviaButton").style.visibility = "visible";
    document.getElementById("studioButton").style.visibility = "hidden";

    fetch(localHost + "filmstudio")
        .then(function (response) {
            return response.json();
        })
        .then(function (json) {

            const user = json[localStorage.getItem("userId")];
            displayUser.innerHTML = user.name;

        });

    //Inline kodning, lägger till en loggaut-knapp
    login.insertAdjacentHTML("beforeend", "<div><button class='logoutButton' id='logoutButton'>Logga Ut</button></div>");

    var logoutButton = document.getElementById("logoutButton");

    logoutButton.addEventListener("click", function () {
        localStorage.removeItem("userId");
        showLoginPage();
        location.reload();
    });
};

//----------------------------------------------------


//Hämtning av Data
//Hämtar data beroende på vilken endpoint som skickas in.
async function getDataAsync(endpoint) {
    let response = await fetch(localHost + endpoint);
    let data = await response.json()
    return data;
}
//---------------------------------------------------

//Eventlisteners som lyssnar efter knapptryck

//Fetchar alla Filmer
let movieButton = document.getElementById("movieButton");
movieButton.addEventListener('click', function showMovies() {
    getDataAsync("film")
    .then(data => renderMovieList(data))
    .catch(error => { console.log(error) });
});


//Fetchar alla Rentals
let rentalButton = document.getElementById("rentalButton");
rentalButton.addEventListener('click', function showRentals() {
    getDataAsync("RentedFilm")
    .then(data => renderRentalList(data))
    .catch(error => { console.log(error) });
});


//Lägger till studio
let studioButton = document.getElementById("studioButton");
studioButton.addEventListener('click', function renderStudioform() {
    addStudio();
});

// lägger till trivia
let triviaButton = document.getElementById("triviaButton");
triviaButton.addEventListener('click', function renderTriviaForm() {
    addTrivia();
});


//------------------------------------------------


//Funktioner som bygger ihop datan

// renderar bilderna till filmerna
function renderImage() {
    var img = document.createElement('img');
    img.className = "movieImage";
    img.src = 'wwwroot/placeholder.png';
    document.getElementById('rendered-content').appendChild(img);
}

//skapar div:arna jag sedan fyller med data
function creatingDiv(element, parentDiv){
    let createdDiv = document.createElement("div");
    createdDiv.className = "createdDiv";
    createdDiv.id = element.id;
    createdDiv.innerHTML = element;

    parentDiv.appendChild(createdDiv);
    return createdDiv;
};

//Ta in ett objekt som innehåller filmid och studioid, samt texten på knappen och "föräldradiven"
function creatingButton(endpoint,id, data , text, parentDiv){
    let buttonDiv = document.createElement("button");
    buttonDiv.className = "buttonDiv";
    buttonDiv.id = id;
    buttonDiv.innerHTML = text;
    
    parentDiv.appendChild(buttonDiv);
    const button =document.getElementById(buttonDiv.id);

    button.addEventListener('click', function(){
        if (data != null) {
            addData(endpoint,data);
        }
        else{
            deleteData(endpoint,id);
        }
    });
};

//Bygger ihop listan på filmer
async function renderMovieList(listOfMovies){
    let contentDiv= document.getElementById("rendered-content");
    contentDiv.innerHTML ="";
    let listOfTrivias = await getDataAsync("filmTrivia");
    let print;

    getDataAsync("filmStudio")
        .then(function (userInStorage) {
           
        const user = userInStorage[localStorage.getItem("userId")];

            for (let i = 0; i < listOfMovies.length; i++) {
                renderImage();
                
                print = "Namn: " + listOfMovies[i].name + "<br>Antal kopior: " + listOfMovies[i].stock + "<hr>";
                if (user !=null) {
                //skicka in endpointen samt filmid:et och användarId:et i ett datapaket
                creatingButton( "Rentedfilm",listOfMovies[i].id, data={ "filmId":listOfMovies[i].id, "studioId":user.id},"rent",creatingDiv(print, contentDiv));
                }
                else{
                    creatingDiv(print, contentDiv);
                };

                for (let j = 0; j < listOfTrivias.length; j++) {
                    
                    if (listOfMovies[i].id == listOfTrivias[j].filmId) {
                        creatingDiv("- "+listOfTrivias[j].trivia, contentDiv);
                    }
                }
                var line = document.createElement('hr'); // Giving Horizontal Row After Heading
                contentDiv.appendChild(line);
                var line = document.createElement('br');
                contentDiv.appendChild(line);
            };
        })
};

//Bygger listan med filmer studion har hyrt
async function renderRentalList(listOfRentals){
    let contentDiv= document.getElementById("rendered-content");
    contentDiv.innerHTML ="";

     getDataAsync("filmStudio")
    .then(function (userInStorage) {

        const user = userInStorage[localStorage.getItem("userId")].id;
        listOfRentals.forEach(rental => {
            //Om RentalId:et matchar userId
            if (rental.studioId == user) {
                //hämta listan filmer
                 getDataAsync("film")
                .then(function (listOfMovies) {
                    //leta i listan filmer efter en film som har samma id som rental:en
                    listOfMovies.forEach(movie => {
                        if (movie.id == rental.filmId) {
                            //skicka varje film som mathar id:et till metoden som skriver ut filmen
                            
                            creatingButton("RentedFilm",rental.id,null, "return", creatingDiv(movie.name, contentDiv));
                        }
                    });

                });
            }
        });
    });
};

//Visar ett "formulär" för att lägga till en Studio
function addStudio(){
let studioAdd = document.getElementById("rendered-content") 
//Töm sidan
studioAdd.innerHTML = "";

//Inline-kodning lägger till två inputfält och en logga-in knapp
studioAdd.insertAdjacentHTML("afterbegin", ' Name: <input class="login" id="addUser" type="text"> Password: <input class="login" id="addPword" type="password"> <button class="submitBtn" id="submitBtn">Submit</button>');

let loginButton = document.getElementById("submitBtn");

//lyssnar på ett knapptryck och börjar processa informationen som angavs
loginButton.addEventListener("click", function () {
    let getUser = document.getElementById("addUser");
    let getPass = document.getElementById("addPword");

    data={ "name": getUser.value, "password": getPass.value, "verified": true}
    addData("filmStudio", data);
});

};

//Ett "formulär" för att lägga in en trivia
function addTrivia(){
let contentDiv = document.getElementById("rendered-content") 
//Töm sidan
contentDiv.innerHTML = "";

var heading = document.createElement('h2'); // Heading of Form
heading.innerHTML = "Add a Trivia";
contentDiv.appendChild(heading);

var line = document.createElement('hr'); // Giving Horizontal Row After Heading
contentDiv.appendChild(line);

var linebreak = document.createElement('br');
contentDiv.appendChild(linebreak);

var movieInputLabel = document.createElement('label'); // Create Label for Name Field
movieInputLabel.innerHTML = "MovieId: "; // Set Field Labels
contentDiv.appendChild(movieInputLabel);

var movieDiv = document.createElement('input'); // Create Input Field for Name
movieDiv.className = "inputField";
movieDiv.id = "movieInput"
contentDiv.appendChild(movieDiv);

var linebreak = document.createElement('br');
contentDiv.appendChild(linebreak);

var triviaLabel = document.createElement('label'); // Append Textarea
triviaLabel.innerHTML = "Trivia: ";
contentDiv.appendChild(triviaLabel);

var triviaDiv = document.createElement('textarea');
triviaDiv.className ="input";
triviaDiv.id ="triviaInput"
contentDiv.appendChild(triviaDiv);

var messagebreak = document.createElement('br');
contentDiv.appendChild(messagebreak);

var submitTriviaBtn = document.createElement('button'); // Append Submit Button
submitTriviaBtn.className ="button";
submitTriviaBtn.id ="submitBtn"
submitTriviaBtn.innerText ="Submit";
contentDiv.appendChild(submitTriviaBtn);

let submit = document.getElementById("submitBtn");
submit.addEventListener("click", function () {
    let getMovie = document.getElementById("movieInput").value;
    let getTrivia = document.getElementById("triviaInput").value;
    let getMovieId = parseInt(getMovie);

    data={ "filmId": getMovieId, "trivia": getTrivia}
    addData("filmTrivia", data);
});
}


//--------------------------------------

//Post and Delete Data


//ta in en endpoint och ett färdigbyggt objekt
function addData(endpoint, object, ){

    // Gör en fetch med localhost och endpointen
    // Inkludera det objektet(skall vara färdigbyggt)
    const localhost = "https://localhost:44361/api/";
    fetch(localhost + endpoint, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(object),
    })
    .then(response => response.json())
    .then(object => {
        console.log("Success!!", object)
    })
    .catch((error) => {
        console.log(error)
    });
};

//endpoint ska innehålla endpointen och id:et
function deleteData(endpoint,id ) {
    const localhost = "https://localhost:44361/api/";
    fetch(localhost + endpoint+"/"+id, {
        method: "DELETE",
    })
    .then(response => response.json());
    location.reload();
};

//------------------------

