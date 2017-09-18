// Write your Javascript code.

$("#nav-shopping-cart").on("click", function (evt) {
  evt.preventDefault();
  $(".cart--floating").slideToggle();
})
