function show(){
    articles.forEach((article, index) => {
        if (index <= (page * article_count)-1 && index >= ((page - 1) * article_count)) {
            article.style.display = 'flex';
            article.style.order = index;
        } 
        else {
            article.style.display = 'none'
        }
    });
}

function next_page() {
    if (page < page_count_total) {
        page++;
        document.getElementById('count__of__pages').innerText = page + ' / ' + page_count_total;
        show(article_count, articles);
        document.getElementById('previous__page').style.display = "inline-block";
        if (page == page_count_total) document.getElementById('next__page').style.display = "none";
    }
}

function previous_page() {
    if (page > 1) {
        page--;
        document.getElementById('count__of__pages').innerText = page + ' / ' + page_count_total;
        show(article_count, articles);
        document.getElementById('next__page').style.display = "inline-block";
        if (page == 1) document.getElementById('previous__page').style.display = "none";
    }
}

function close_dialog(){
    let dialog = document.getElementById('article__dialog');
    dialog.close();
}

function open_dialog(){
    let dialog = document.getElementById('article__dialog');
    if (typeof dialog.showModal === "function") {
        dialog.showModal();
    } else {
        console.log("The <dialog> API is not supported by this browser");
    }
}

function create_article(){
    let name = document.getElementById('form__input').value;
    if (name != '') {
        window.location = 'https://webik.ms.mff.cuni.cz/~13176152/cms/?page=article-create&name=' + name;
    }
}

function delete_article(el){
    const id = el.parentElement.parentElement.id;
    fetch(
    "App/api/fetch-delete.php?delId="+id,
    {method: "DELETE"})
    .then((response) => response.json())
    .then((data) => {
        console.log('Success:', data);
        const parent = document.getElementById('article__list');
        const delete_child = document.getElementById(id);
        parent.removeChild(delete_child);

        article_count_total-=1;
        page_count_total = Math.ceil(article_count_total / article_count);
        if (article_count_total == 0) document.getElementById('empty__list').style.display = 'block';
        if (page_count_total == 0) page_count_total = 1;
        articles = document.querySelectorAll('.article');
        show(10, articles);
        document.getElementById('count__of__pages').innerText = page + ' / ' + page_count_total;
    })
    .catch((error) => {
        console.error('Error:', error);
    });

}

function sort(){
    if (sortt==false){
        articles.sort(function(a, b) {
            return b.getAttribute("score") - a.getAttribute("score");
          });
        show(article_count, articles);
        sortt=true;
    }
    else{
        articles_array = document.getElementsByClassName('article')
        sortt=false;
        articles = [];
        for (var i = articles_array.length - 1; i >= 0; i--) {
            articles.push(articles_array[i]);
        }

        articles.forEach((article, index) => {
            article.style.display = 'none'
        });

        show(article_count, articles);
    }
}

document.getElementById('next__page').addEventListener('click', next_page);
document.getElementById('previous__page').addEventListener('click', previous_page);
document.getElementById('previous__page').style.display = "none";
document.getElementById('openDialogButton').addEventListener('click', open_dialog);
document.getElementById('closeDialog').addEventListener('click', close_dialog);
document.getElementById('submit').addEventListener('click', create_article);
document.getElementById('sort-check').addEventListener('click', sort);

let delete_btns = document.querySelectorAll('.delete');
delete_btns.forEach((btn) => {
    btn.addEventListener('click', () => {
        delete_article(btn);
    });
});


const article_count = 10;

let page = 1;
let articles_array = document.getElementsByClassName('article')

let sortt=false;
let articles = [];
for (var i = articles_array.length - 1; i >= 0; i--) {
    articles.push(articles_array[i]);
  }


let article_count_total = document.getElementsByClassName('article').length;
if (article_count_total != 0){
    document.getElementById('empty__list').style.display = 'none';
}

let artt = [];

let page_count_total = Math.ceil(article_count_total / article_count);
if (page_count_total == 0) page_count_total = 1;

show(article_count, articles);
document.getElementById('count__of__pages').innerText = page + ' / ' + page_count_total;