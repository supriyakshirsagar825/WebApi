/// <reference path="jquery-3.4.1.min.js" />

import { localstorage } from "modernizr";


function getAccesstoken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token')[1].split('&')[0];
            if (accesstoken) {
                isUserRegistered(accessToken);
            }
        }
    }
}

function isUserRegistered(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'Get',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer' + accessToken
        },
        suceess: function (response) {
            if (response.HasRegistered) {
                localstorage.setitem('accessToken', accessToken);
                localstorage.setitem('userName', response.Email);
                window.location.href = "data.html";
            }
            else {
                SignUpExternalUser(accessToken);
            }
        },
    });
}


function SignUpExternalUser(accessToken) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'Post',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer' + accessToken
        },
        suceess: function (response) {
            window.Location.href = "Login.html";
        },
    });
}






