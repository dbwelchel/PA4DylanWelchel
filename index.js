const url = "https://localhost:7223/api/Exercise"

let myActivity = [];
async function handleOnLoad() {
  const response = await fetch(url);
  const data = await response.json();
  
  if (response.ok) {
    console.log(data);
    myActivity = data;
    displayExercise(myActivity);
  }
  
  
}
  function displayExercise(myActivity){
  
  

  // document.getElementById('app').innerHTML=html;
  //sort each activity by date
  myActivity.forEach(exercise => {
    exercise.date = new Date(exercise.date);
  });
  myActivity.sort((firstDate, secondDate) => secondDate.date - firstDate.date);
  populateTable(myActivity);    
}

async function populateTable(myActivity) {
  let tableBody = document.getElementById('app');
    if (tableBody) {
      await getAllExercise(myActivity);
// document.getElementById('app').innerHTML=html;

myActivity.forEach(exercise => {
  exercise.date = new Date(exercise.date);
});
myActivity.sort((firstDate, secondDate) => secondDate.date - firstDate.date);
html  = ` <div class="mb-3 bg-body-tertiary rounded-3">
<div class="container-fluid py-5">
  <h1 class="display-5 fw-bold text-danger">Roll(with)TideFit</h1>
  <p class="col-md-8 fs-4 text-muted">For those who are always on the go, TideFit is here to help you track and meet all of your fitness expectations.</p>
</div>
</div>` 
html += `
  <table class="table table-striped">
  <tr>
    <th>Exercise ID</th>
    <th>Activity</th>
    <th>Miles</th>
    <th>Date</th>
    <th>Pin Exercise</th>
    <th>Delete Exercise</th>
  </tr>`;

  myActivity.forEach(function(exercise) {
    if(exercise.miles==undefined) {
      exercise.miles = 0;
    }
    html +=`  
      <tr>
      <td>${exercise.id}</td>
      <td>${exercise.activity}</td>
      <td>${exercise.miles}</td>
      <td>${exercise.date}
      </td>`
      
      
      html +=
        //Pin:Unpin button
        `<td><button class="btn btn-primary" onclick="pinActivity(${myActivity.indexOf(exercise)})">${exercise.Pinned}</button></td>
        <td><button class ="btn btn-danger" onclick="handleExerciseDelete('${exercise.id}')">Delete</button></td>
        </tr>`;
  })
  html+= `</table>`
  html += `
    <div id="tableBody"></div>
    <form onsubmit="return false">
      
      <label for="active">Activity:</label><br>
      <input type="text" id="active" name="active"><br>
      <label for="miles">Miles:</label><br>
      <input type="text" id="miles" name="miles"><br>
      <label for="date">Date:</label><br>
      <input type="date" id="date" name="date"><br>
      <button onclick="handleActivityAdd()" class="btn btn-primary"> SUBMIT </button>
    </form>`;
  tableBody.innerHTML = html;
} else {
    console.error("tableBody element not found");
}
}

async function handleActivityAdd() {
  
  
    let myuuid = uuidv4();;
    let exercise = {Id: myuuid, Activity: document.getElementById('active').value, Miles: document.getElementById('miles').value, Date: document.getElementById('date').value};
     myActivity.push(exercise);
    await saveExercise(exercise);
     populateTable();
    document.getElementById('active').value = '';
    document.getElementById('miles').value = '';
    document.getElementById('date').value = '';
  }



function pinActivity(index) {
  const exercisePin = myActivity[index];
  console.log(exercise); 

  if (exercisePin.Pinned === "Pin") {
    exercisePin.Pinned = "Unpin";
  } else if (exercisePin.Pinned === "Unpin") {
    exercise.Pinned = "Pin";
  }


  myActivity.sort((firstDate, secondDate) => secondDate.date - firstDate.date);
  populateTable();
}
async function handleExerciseDelete(id) {
  console.log('You called me? ' , id);
  let deleteURL = url + '/' + id
  console.log(deleteURL)
  // myBooks = myBooks.filter(book => book.Title != title);
  await fetch(deleteURL, {
    method: "DELETE",

  });
  populateTable();
}


async function getAllExercise() {
  let response = await fetch(url);
  myBooks = await response.json();
}
async function saveExercise(exercise) {
  console.log("what book am i saving", exercise)
 await fetch(url, {
    method: "POST",
    body: JSON.stringify(exercise), 
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
}