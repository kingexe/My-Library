<template>
    <div class="container mt-4">
    <div class="row justify-content-center">
      <div class="col-md-6">
        <div class="card">
          <div class="card-header  text-black">
            <h3 class="card-title">Edit Book</h3>
          </div>
          <div class="card-body">
            <form @submit.prevent="addBook">
              <div class="mb-3">
                <label for="title" class="form-label">Title:</label>
                <input type="text" class="form-control" id="editTitle" v-model="editBook.title" />
              </div>
              <div class="mb-3">
                <label for="author" class="form-label">Author:</label>
                <input type="text" class="form-control" id="editAuthor" v-model="editBook.author" />
              </div>
              <div class="mb-3">
                <label for="publicationYear" class="form-label">Publication Year:</label>
                <input type="text" class="form-control" id="editPublicationYear" v-model="editBook.publicationYear" />
              </div>
              <button type="submit" class="btn btn-primary" @click="saveEditedBook">Save Changes</button>
              <p v-if="message" class="mt-3 alert alert-success">{{ message }}</p>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const editBook = ref({
  id: null,
  title: '',
  author: '',
  publicationYear: ''
});

const router = useRouter();
const bookId = router.currentRoute._value.params.id;
var message = '';

// Fetch the book details for editing
const fetchBookDetails = async (id) => {
    console.log();
  try {
    const response = await fetch(`https://localhost:5001/api/books/${id}`);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    editBook.value = data;
  } catch (error) {
    console.error('Error fetching book details for editing:', error);
  }
};

onMounted(() => {
  console.log(router);
  console.log(bookId);
  fetchBookDetails(bookId);
});


const saveEditedBook = async () => {
    console.log(editBook.value);
  try {
    // Send a PUT request to update the book details
    const response = await fetch(`https://localhost:5001/api/books/${editBook.value.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(editBook.value)
    });

    if (!response.ok) {
        console.log('not ok')
          alert("Not Working");
      throw new Error('Network response was not ok');
    }else{
        console.log(' ok')
        // After saving the changes, navigate back to the list page
         alert("Book Edited successfully!");
         router.back()
    }

    
    
  } catch (error) {
    console.error('Error saving edited book:', error);
  }
};

</script>
