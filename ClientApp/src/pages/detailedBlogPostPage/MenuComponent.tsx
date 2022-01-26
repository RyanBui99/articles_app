import React, { useState } from 'react';
import IconButton from '@mui/material/IconButton';
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import EditBlogPostModal from '../../components/modals/EditBlogPostModal';
import { CardActions } from '@material-ui/core';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import { APIService } from '../../helpers/APIService';
import { useNavigate } from 'react-router-dom';

interface Prop {
  blogPostId: string;
  blogPost: IStorageBlogPosts;
}

export default function MenuComponent({ blogPostId, blogPost }: Prop) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const navigate = useNavigate();
  
  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  const deleteBlogPost = async () => {
    await APIService.deleteBlogPost(blogPostId);
    navigate('/');
  };

  return (
    <>
      <CardActions>
        <IconButton onClick={openModal} sx={{ padding: '0' }}>
          <ModeEditOutlineOutlinedIcon color='primary' />
        </IconButton>
        <IconButton onClick={deleteBlogPost} sx={{ padding: '0' }}>
          <DeleteOutlinedIcon color='error' />
        </IconButton>
      </CardActions>
      <EditBlogPostModal
        closeModal={closeModal}
        isModalOpen={isModalOpen}
        blogPost={blogPost}
      />
    </>
  );
}
