const threshold = .1
const options = {
  root: null,
  rootMargin: '0px',
  threshold
}

const handleIntersect = function (entries, observer) {
  entries.forEach(function (entry) {
    if (entry.intersectionRatio > threshold) {
      entry.target.classList.remove('reveal')
      observer.unobserve(entry.target)
    }
  })
}

document.documentElement.classList.add('reveal-loaded')

window.addEventListener("DOMContentLoaded", function () {
  const observer = new IntersectionObserver(handleIntersect, options)
  const targets = document.querySelectorAll('.reveal')
  targets.forEach(function (target) {
    observer.observe(target)
  })
})


var konamiStarted = false;
i = 0;
let konamiList = [38, 38, 40, 40, 37, 39, 37, 39, 66, 65];


document.onkeydown = testKeyEvent;


function testKeyEvent(e) {
  setTimeout(function() {
    if (e.keyCode == konamiList[i])
    {
        i++;
        if (i == konamiList.length)
        {
          if (window.confirm("Voulez-vous rejoindre notre bot discord ?")) {
            window.open('https://discord.gg/9gNSJP2wFR', '_blank');
          }
        }
    }
    else 
    {
        i = 0;
    }
  }, 500);
}
