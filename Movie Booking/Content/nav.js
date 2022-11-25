const nav = document.getElementById("myNav")
const header = document.getElementById("header")
const open = document.getElementById("open")
const Nav = document.getElementsByClassName("Nav")
const close = document.getElementById("close")

open.classList.add("Responsive")

const down = () => {
    nav.classList.toggle("responsive")
    open.classList.remove("Responsive")
    close.classList.add("Responsive")
    header.classList.toggle("header")
    Nav.classList.toggle("Full")
}

const up = () => {
    nav.classList.toggle("responsive")
    open.classList.add("Responsive")
    close.classList.remove("Responsive")
    header.classList.toggle("header")
    Nav.classList.toggle("Full")
}