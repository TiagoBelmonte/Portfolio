// Deze opdracht bestaat uit drie stukjes :
// 1) zorg dat de setup functie wordt uitgevoerd na het inladen vd pagina
// 2) schrijf de setup functie
// 3) schrijf de clickImage functie

// Gegeven zijn twee parallele arrays (dwz dat elementen op eenzelfde positie in deze arrays, samen horen)
// die personages beschrijven. Het ene bevat de naam van het personage en het andere bevat
// de url van de afbeelding van dat personage.
const names = ["Al Bundy", "Peggy Bundy", "Kelly Bundy", "Bud Bundy", "Buck Bundy"];
const urls = ["images/al.webp", "images/peg.webp", "images/kelly.webp", "images/bud.webp", "images/buck.webp"];
// Bijvoorbeeld op indexpositie 1 vinden we alle info over personage Peggy :
// haar naam staat op positie 1 in array "names"
// de url van haar afbeelding staat op positie 1 in array "urls"


// Zorg ervoor dat deze setup functie wordt opgeroepen zodra de browser klaar is met het inladen van de pagina
const setup = () => {
    // De inhoud van de parallele arrays beschrijft de personages (naam en afbeelding url).
    // Voeg voor elk personage een <img> toe (zoals beschreven in de broncode van het HTML document),
    // en gebruik hiervoor insertAdjacentHTML. Koppel aan elke afbeelding een click event listener
    // die de functie clickImage oproept.

    let divTasks = document.getElementsByClassName("image-selection")[0];

    for (let i = 0; i < urls.length; i++) {
        divTasks.insertAdjacentHTML("beforeend", `<img class="selectable" src=${urls[i]}>`);
        divTasks.addEventListener("click", clickImage)
    }
}

// Dit is de functie die wordt opgeroepen bij een klik op de afbeelding van een personage
    const clickImage = (event) => {
        // Deze functie wijzigt de selectie :
        // - indien klik op reeds geselecteerde afbeelding : er is geen geselecteerd personage meer
        // - indien klik op andere afbeelding : selecteer dat personage

        // Een geselecteerd personage leidt tot 2 visuele aanpassingen : de afbeelding en de naam.

        // De afbeelding van dit geselecteerde personage heeft een rood kader (via class "selected"),
        // andere afbeeldingen hebben deze class "selected" niet!

        // De naam van het geselecteerde personage verschijnt onderaan in een <span> met class "result",
        // indien er geen selectie is, bevat die span gewoon een lege string.

        // Tip : als je de naam van een personage moet achterhalen, bedenk dan dat je bij een klik makkelijk
        // de url kunt achterhalen van de geklikte afbeelding. Met die url kun je in het array "urls"
        // op zoek gaan naar de positie van die url. Op dezelfde positie in het "names" array vind je
        // dan de gezochte naam.
        //
        // Bijvoorbeeld, een klik op afbeelding met url "images/peg.webp" doet ons zoeken in
        // array "urls" naar precies die url. We vinden die url op indexpositie 1 in array "urls"
        // en op diezelfde positie in het "names" array vinden we de naam "Peggy Bundy".

        let afbeeldingengeselecteerd = document.getElementsByClassName("selected")
        let afbeelding = event.target;
        let url = afbeelding.getAttribute("src");

        let positieFoto = urls.indexOf(url)
        let result = document.getElementsByClassName("result")


        if(afbeeldingengeselecteerd.length<1)
        {
            afbeelding.classList.add("selected")
            result[0].textContent = names.at(positieFoto)
        }
        else if(afbeeldingengeselecteerd[0].getAttribute("src")== url)
        {
            afbeeldingengeselecteerd[0].classList.remove("selected")
            result[0].textContent=""

        }
        else
        {
            afbeeldingengeselecteerd[0].classList.remove("selected")
            afbeelding.classList.add("selected")
            result[0].textContent = names.at(positieFoto)
        }



    }
window.addEventListener("load", setup);

