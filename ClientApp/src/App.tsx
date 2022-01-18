import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import AdminPage from './pages/adminPage/AdminPage';
import ArticlesPage from './pages/blogPage/BlogPage';
import LoginPage from './pages/loginPage/LoginPage';
import RegisterPage from './pages/registerPage/RegisterPage';

function App() {
  return (
    <div className='App'>
      <BrowserRouter>
        <Routes>
          <Route path='/login' element={<LoginPage />} />
          <Route path='/register' element={<RegisterPage />} />
          <Route path='/admin/dashboard' element={<AdminPage />} />
          <Route path='/' element={<ArticlesPage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
