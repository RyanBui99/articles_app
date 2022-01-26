import React, { useEffect, useState } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import CloseIcon from '@mui/icons-material/Close';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
import { Box, IconButton, DialogTitle } from '@material-ui/core';
import SnackbarComponent from '../SnackbarComponent';
import { useDispatch } from 'react-redux';
import { editBlogPost } from '../../store/actionCreators/blogPostCreator';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import { IEditBlogPost } from '../../interfaces/IEditBlogPost';
import BlogPostContent from '../BlogPostContent';
import { AlertColor } from '@mui/material';

interface Prop {
  closeModal: () => void;
  isModalOpen: boolean;
  blogPost: IStorageBlogPosts;
}

export default function EditBlogPostModal({
  closeModal,
  isModalOpen,
  blogPost,
}: Prop) {
  const theme = useTheme();
  const dispatch = useDispatch();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>();
  const [imageToServer, setImageToServer] = useState<File>();
  const [image, setImage] = useState('');
  const [imageName, setImageName] = useState('');

  useEffect(() => {
    setImage(blogPost.imageSrc);
    setImageName(blogPost.imageName);
  }, [blogPost.imageSrc, blogPost.imageName]);

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const selectedFile = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;
    const imageUrl = URL.createObjectURL(e.target.files[0]);
    setImage(imageUrl);
    setImageToServer(e.target.files[0]);
    setImageName(e.target.files[0].name);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const editedBlogData: IEditBlogPost = {
      header: data.get('header')!.toString(),
      content: data.get('content')!.toString(),
      imageFile: imageToServer,
      imageName: imageName,
    };
    try {
      dispatch(editBlogPost(blogPost.id, editedBlogData));
      setSeverity('success');
      setMessage('Your post has been edited!');
      closeModal();
    } catch (error: any) {
      setMessage(error.response.data.message);
      setSeverity('error');
    }
  };

  return (
    <>
      <SnackbarComponent
        open={open}
        handleClose={handleClose}
        message={message}
        severity={severity}
      />
      <Dialog
        fullScreen={fullScreen}
        open={isModalOpen}
        onClose={closeModal}
        aria-labelledby='responsive-dialog-title'
        fullWidth
        maxWidth='lg'
      >
        <DialogActions
          sx={{ display: 'flex', justifyContent: 'space-between' }}
        >
          <DialogTitle id='responsive-dialog-title'>Edit Blog Post</DialogTitle>
          <IconButton
            edge='start'
            color='inherit'
            onClick={closeModal}
            aria-label='close'
          >
            <CloseIcon />
          </IconButton>
        </DialogActions>
        <DialogContent dividers>
          <Box component='form' onSubmit={handleSubmit} width='100%'>
            <BlogPostContent
              selectedFile={selectedFile}
              image={image}
              blogPost={blogPost}
            />
            <DialogActions>
              <Button onClick={handleClick} autoFocus type='submit'>
                Confirm Edit
              </Button>
            </DialogActions>
          </Box>
        </DialogContent>
      </Dialog>
    </>
  );
}
