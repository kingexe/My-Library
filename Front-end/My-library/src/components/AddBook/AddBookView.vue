<template>
  <div class="container mt-4">
    <div class="row justify-content-center">
      <div class="col-md-6">
        <div class="card">
          <div class="card-header  text-black">
            <h3 class="card-title">Add New Book</h3>
          </div>
          <div class="card-body">
            <form @submit.prevent="addBook">
              <div class="mb-3">
                <label for="title" class="form-label">Title:</label>
                <input type="text" id="title" v-model="book.title" class="form-control" required>
              </div>
              <div class="mb-3">
                <label for="author" class="form-label">Author:</label>
                <input type="text" id="author" v-model="book.author" class="form-control" required>
              </div>
              <div class="mb-3">
                <label for="publicationYear" class="form-label">Publication Year:</label>
                <input type="number" id="publicationYear" v-model="book.publicationYear" class="form-control" required>
              </div>
              <button type="submit" class="btn btn-primary">Add Book</button>
            </form>
            <p v-if="message" class="mt-3 alert alert-success">{{ message }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  data() {
    return {
      book: {
        title: '',
        author: '',
        publicationYear: null,
      },
      message: '',
    };
  },
  methods: {
    addBook() {
      // Send a POST request to the back-end API to add the book
      fetch('https://localhost:5001/api/books', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.book),
      })
        .then((response) => response.json())
        .then((data) => {
          // Clear the form fields after adding the book
          this.book.title = '';
          this.book.author = '';
          this.book.publicationYear = null;

          // Show a success message
          this.message = 'Book added successfully!';
        })
        .catch((error) => {
          // Show an error message if there's an issue with the API
          this.message = 'Error adding the book.';
          console.error(error);
        });
    },
  },
};
</script>
