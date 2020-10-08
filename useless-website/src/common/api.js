import fetch from 'cross-fetch'

export function apiGet(endpoint) {

    const token = localStorage.token;

    if (token) {
        return fetch(process.env.REACT_APP_API_URL + endpoint, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        }).then(response => response.json());
    } else {
        return fetch(process.env.REACT_APP_API_URL + endpoint, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        }).then(response => response.json());
    }
}

export function apiPost(endpoint, body) {

    const token = localStorage.token;
    if (token) {
        return fetch(process.env.REACT_APP_API_URL + endpoint, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(body)
        }).then(resp => resp.json());
    } else {
        return fetch(process.env.REACT_APP_API_URL + endpoint, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(body)
        }).then(resp => resp.json());
    }
}