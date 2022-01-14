import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import AdminPage from './pages/adminPage/AdminPage';
import ArticlesPage from './pages/articlesPage/ArticlesPage';
import LoginPage from './pages/loginPage/LoginPage';

function App() {
  return (
    <div className='App'>
      {/* <BrowserRouter>
        <Routes>
          <Route path='admin/login' element={<LoginPage />} />
          <Route path='admin/adminPanel' element={<AdminPage />} />
          <Route path='/' element={<ArticlesPage />} />
        </Routes>
      </BrowserRouter> */}
      <ArticlesPage />
    </div>
  );
}

export default App;
