const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen
    begroeten();
    vierkantSter();
    drieVijfVouden();
}

const begroeten = () => {
    console.log("Hello world!!!!!!!")
}

const vierkantSter = () =>{
    const aantalRegels=4;

    let sterretjes="";
    for (let i=0;i<aantalRegels;i++) {
        for (let i=0;i<aantalRegels;i++) {
            sterretjes+="*";
        }
        sterretjes+="\n";
    }
    console.log(sterretjes);
}
const drieVijfVouden = () => {
    let som = 0;
    for (let i = 1; i < 500; i++) {
        if (i % 3 === 0 || i % 5 === 0) {
            console.log(i);
            som += i;
        }
    }
    console.log("de totale som is: " + som);
}

window.addEventListener("load", setup);