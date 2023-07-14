function setQueryString(name, value) {

    let queryParams = new URLSearchParams(window.location.search);
    if (value) {
        queryParams.set(name, value);
    }
    else {
        queryParams.delete(name)
    }
    window.location.href = window.location.href.split('?')[0] + '?' + queryParams.toString();
}