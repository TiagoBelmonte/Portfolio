
const setup = () => {

        let gemeenten = [];
    let stoppen=true;
    while(stoppen) {
        let input = window.prompt("Geef een gemeente in (of 'stop' om te stoppen)");

        if(input==null ||input.toLowerCase()=="stop" )
        {
            stoppen = false;
        }
        else
        {
            gemeenten.push(input);
        }
    }

    gemeenten.sort(compare);
    voegGemeentenToe(gemeenten);

};

const voegGemeentenToe = (gemeenten) => {

    let Gemeenten = document.querySelector("#selGemeenten");

    for (let i = 0; i < gemeenten.length; i++) {

        Gemeenten.insertAdjacentHTML("beforeend", `<option>${gemeenten[i]}</option>`);
    }
};


    const compare = (a,b) => {
        return a.localeCompare(b);
    };

window.addEventListener("load", setup);