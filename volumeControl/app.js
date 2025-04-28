const main = document.getElementById("main");
const volumeFill = document.getElementById("volume-fill");

const icons = [
  {
    imageSrc: "./images/vol1.png",
    value: 5,
  },
  {
    imageSrc: "./images/vol2.png",
    value: -5,
  },
  {
    imageSrc: "./images/vol3.png",
    value: 15,
  },
  {
    imageSrc: "./images/vol4.png",
    value: -7,
  },
  {
    imageSrc: "./images/vol5.png",
    value: "full",
  },
  {
    imageSrc: "./images/vol6.png",
    value: "empty",
  },
  {
    imageSrc: "./images/vol7.png",
    value: "mute",
  },
  {
    imageSrc: "./images/vol8.png",
    value: "unmute",
  },
];

let volume = 10;
let currentVolume = 0;
let muted = false;

function updateVolume(action) {
  if (typeof action == "number") {
    volume = Math.max(0, Math.min(100, volume + action));
  } else if (action == "full") {
    volume = 100;
  } else if (action == "empty") {
    volume = 0;
  } else if (action == "mute" && muted == false) {
    currentVolume = volume;
    volume = 0
    muted = true
  } else if(action == "unmute" && muted == true){
   volume = currentVolume
   muted = false
  }

  volumeFill.style.width = volume +"%"
}

function showIcon(){

   const icon = document.createElement("div")
   const id = Math.floor(Math.random()*icons.length)
   
   icon.className = "icon"
   icon.style.backgroundImage = `url(${icons[id].imageSrc})`

   const x = Math.random() * (main.clientWidth - 55)
   const y = Math.random() * (main.clientHeight - 45)
   icon.style.left = x + "px"
   icon.style.top = y + "px"

   main.appendChild(icon)
   requestAnimationFrame(() => { icon.style.opacity = 1; });

   icon.addEventListener("click", () => {

      updateVolume(icons[id].value)
      removeIcon(icon)

   })

   setTimeout(()=>removeIcon(icon), 6000)
}

// setInterval(showIcon,1500)

function removeIcon(icon){
   icon.parentNode.removeChild(icon)
}


