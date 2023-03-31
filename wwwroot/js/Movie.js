



function ChangingFavStar() {
    var Check = true;
    document.getElementById("FavMovie").addEventListener("click", () => {
        if (Check == true) {
            document.getElementById("FavStar").classList.add('full');
            Check = false;
        }

        else if (Check == false) {
            document.getElementById("FavStar").classList.remove('full');
            Check = true;
        }
    })
}

ChangingFavStar();

function ChangingRatingStar() {
    var Check1 = true;
    document.getElementById("SaveRating").addEventListener("click", () => {
        if (Check1 == true) {
            document.getElementById("RatingStar").classList.add('full');
            Check1 = false;
        }

        //else if (Check1 == false) {
        //    document.getElementById("RatingStar").classList.remove('full');
        //    Check1 = true;
        //}
    })
}


ChangingRatingStar(); 

function myFun() {
    if (document.getElementById("myMovie").style.display == "none")
        document.getElementById("myMovie").style.display = "block";
    else {
        document.getElementById("myMovie").style.display = "none";
    }
}

document.getElementById("watchMovieBtn").addEventListener("click", myFun); 
 

