const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let paraf = document.getElementsByClassName("belangrijk");

    for (let i = 0;i<paraf.length;i++)
    {
        paraf[i].classList.add("opvallend");
    }
}


window.addEventListener("load", setup);