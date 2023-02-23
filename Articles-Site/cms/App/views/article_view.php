<script type="text/javascript">
    let rated = false;
    function edit(){
        window.location = 'https://webik.ms.mff.cuni.cz/~13176152/cms/article-edit/<?php echo $data[0]['id']?>'
    }

    function back(){
        window.location = 'https://webik.ms.mff.cuni.cz/~13176152/cms/articles'
    }

    function like(){
        if (rated == false) {
            let newScore = Number(document.getElementById('like').innerText) + 1;
            fetch(
                "../App/api/fetch-like.php?id="+<?php echo $data[0]['id']?>+"&score="+newScore,
                {method: "PUT"})
                .then((response) => response.json())
                .then((data) => {
                    document.getElementById('like').innerText = newScore;
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        }
        rated = true;
    }

    function dislike(){
        if (rated == false) {
            let newScore = Number(document.getElementById('dislike').innerText) + 1;
            fetch(
                "../App/api/fetch-dislike.php?id="+<?php echo $data[0]['id']?>+"&score="+newScore,
                {method: "PUT"})
                .then((response) => response.json())
                .then((data) => {
                    document.getElementById('dislike').innerText = newScore;
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        }
        rated = true;
    }
</script>

<div class="content">
    <div class="paper">
        <div class="article_header">
            <h1><?php echo $data[0]['title']?></h1>
            <div class="article_rated">
                <div class="article__score">
                    <p class="score" id="like"><?php echo $data[0]['like']?></p>
                    <img onclick="like()" src="../lib/img/like.png" alt="like">
                </div>
                
                <div class="article__score">
                    <p id="dislike" class="score"><?php echo $data[0]['dislike']?></p>
                    <img onclick="dislike()" id="dislike" src="../lib/img/dislike.png" alt="dislike">
                </div>
            </div>
        </div>
        <hr>
        <pre style="white-space: pre-wrap">
            <p class="article__content"><?php echo $data[0]['content']?></p>
        </pre>
        <div class="article__show__btns">
            <button class="btn edit" onclick="edit()" is="edit_btn">Edit</button>
            <button class="btn" onclick="back()" is="edit_btn">Back to articles</button>
        </div>
    </div>
</div>
