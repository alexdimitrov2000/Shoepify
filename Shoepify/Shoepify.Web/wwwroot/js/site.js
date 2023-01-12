﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#filter").submit(function () {
        if ($("#name-field").val() == "") {
            $("#name-field").attr("disabled", "disabled");
        }
    });
});

var modal = document.getElementById('modal');

const showModal = () => {
    modal.classList.add('show');
};

const closeModal = () => {
    modal.classList.remove('show');

};