const setup = () => {
    let sliders = document.getElementsByClassName("slider");
    for (let i = 0; i < sliders.length; i++) {
        sliders[i].addEventListener("change", update);
        sliders[i].addEventListener("input", update);
    }
    update();
};

const update = () => {
    let rood=document.getElementById("sldRed").value;
    let groen=document.getElementById("sldGreen").value;
    let blauw=document.getElementById("sldBlue").value;

    document.getElementById("lblRood").textContent=rood;
    document.getElementById("lblGroen").textContent=groen;
    document.getElementById("lblBlauw").textContent=blauw;

    let swatch=document.getElementById("swatch");
    swatch.style.backgroundColor="rgb("+rood+","+groen+","+blauw+")";
};

window.addEventListener("load", setup);