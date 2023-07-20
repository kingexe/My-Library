<template>
  <div class="container mt-5">
    <h2>List of Books</h2>
    <!-- Search Bar -->
    <div class="d-flex justify-content-center mb-3">
      <div class="input-group mb-3" style="margin-top: 20px; max-width: 1000px;">
        <input
          type="text"
          class="form-control"
          placeholder="Search by title"
          v-model="searchQuery"
          @input="searchBooks"
        />
        <button class="btn btn-outline-secondary" @click="clearSearch">Clear</button>
      </div>
    </div>
    <!-- Table -->
    <table class="table table-bordered table-striped">
      <thead>
        <tr>
          <th>Title</th>
          <th>Author</th>
          <th>Publication Year</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <!-- Loop over the filteredBooks  -->
        <tr v-for="book in filteredBooks" :key="book.title">
          <td>{{ book.title }}</td>
          <td>{{ book.author }}</td>
          <td>{{ book.publicationYear }}</td>
          <td>
            <div class="btn-group" role="group">
              <!---<button class="btn btn-primary" @click="openEditModal(book)">Edit</button>-->
              <router-link :to="{name: 'EditBook', params: { id: book.id }}" class="btn btn-primary">Edit</router-link>
              <button class="btn btn-danger" @click="deleteBook(book.id)">Delete</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
/* Add custom CSS to separate the edit and delete buttons */
.btn-group {
  display: flex;
}

.btn-group .btn {
  max-width: 100px;
  margin-left: 35px;
}

.btn-group .btn:not(:last-child) {
  margin-right: 20px;
}

table th:nth-child(4),
table td:nth-child(4) {
  width: 300px;
}
</style>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const books = ref([]);
const filteredBooks = ref([]);
const searchQuery = ref('');
const router = useRouter();

const openEditModal = (book) => {
  router.push({ name: 'edit-book', params: { id: book.id } });
};

const fetchBooks = async () => {
  try {
    const response = await fetch('https://localhost:5001/api/books');
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    books.value = data;
    filteredBooks.value = data; // Set filteredBooks initially to show all books
  } catch (error) {
    console.error('Error fetching books:', error);
  }
};

onMounted(() => {
  fetchBooks();
});

const deleteBook = async (id) => {
  try {
    const response = await fetch(`https://localhost:5001/api/books/${id}`, {
      method: 'DELETE',
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    // If the book is successfully deleted, remove it from the list of books
    books.value = books.value.filter((book) => book.id !== id);
    filteredBooks.value = filteredBooks.value.filter((book) => book.id !== id);
  } catch (error) {
    console.error('Error deleting book:', error);
  }
};

const clearSearch = () => {
  // Clear the search query and show all books again
  searchQuery.value = '';
  filteredBooks.value = books.value;
};

const searchBooks = () => {
  const query = searchQuery.value.toLowerCase();
  filteredBooks.value = books.value.filter(
    (book) =>
      book.title.toLowerCase().includes(query) ||
      book.author.toLowerCase().includes(query) ||
      book.publicationYear.toString().includes(query)
  );
};
</script>
