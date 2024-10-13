const setup = () => {
    // deze code wordt pas uitgevoerd als de pagina volledig is ingeladen
    const getallen = [-1,0,3.6,6,100];
    for(let i = 0;i<getallen.length;i++){
        const clamped = getClamped(3,getallen[i],6.4);
        console.log(`voor ${i} geeft dit ${clamped}`);
    }
}

const getClamped = (min,getal,max) => {
    let result = min;
    if (getal >min){
        if(getal>max){
            result = max;
        } else{
            result = getal
        }
    }
    return result;
}
window.addEventListener("load", setup);