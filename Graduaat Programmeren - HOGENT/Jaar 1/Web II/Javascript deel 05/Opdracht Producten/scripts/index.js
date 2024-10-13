const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen


    let Herberekenen = document.getElementById("Herberekenen");

    Herberekenen.addEventListener("click",berekenen);


}

const berekenen = () =>
{
    let prijzen = document.getElementsByClassName("prijs");
    let aantallen = document.getElementsByClassName("aantal");
    let btws = document.getElementsByClassName("btw");
    let totaal = 0;

    for(let i =0;i<4;i++)
    {
        let aantal=parseFloat(aantallen[i].value);
        let btw=parseFloat(btws[i].textContent);
        let prijs=parseFloat(prijzen[i].textContent);
        let subtotaal=aantal*prijs*(1+(btw/100));
        totaal+=subtotaal;
    }
    const Totaal = document.getElementById("totaal");
    Totaal.textContent = totaal;
}

window.addEventListener("load", setup);