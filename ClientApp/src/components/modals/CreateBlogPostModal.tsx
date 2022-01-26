import React, { useState } from 'react';
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
import { ICreateBlogPost } from '../../interfaces/ICreateBlogPost';
import { createNewPost } from '../../store/actionCreators/blogPostCreator';
import BlogPostContent from '../BlogPostContent';
import { AlertColor } from '@mui/material';

export default function CreateBlogPostModal(props: any) {
  const theme = useTheme();
  const dispatch = useDispatch();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>();
  const [imageToServer, setImageToServer] = useState<File>();
  const [image, setImage] = useState('');

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
    console.log(e.target.files[0]);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const createBlogData: ICreateBlogPost = {
      header: data.get('header')!.toString(),
      content: data.get('content')!.toString(),
      imageFile: imageToServer,
    };
    try {
      dispatch(createNewPost(createBlogData));
      setSeverity('success');
      setMessage('Your post is now published!');
      props.handleclose();
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
        open={props.open}
        onClose={props.handleclose}
        aria-labelledby='responsive-dialog-title'
        fullWidth
        maxWidth='lg'
      >
        <DialogActions
          sx={{ display: 'flex', justifyContent: 'space-between' }}
        >
          <DialogTitle id='responsive-dialog-title'>
            Create new blog post
          </DialogTitle>
          <IconButton
            edge='start'
            color='inherit'
            onClick={props.handleclose}
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
            />
            <DialogActions>
              <Button onClick={handleClick} autoFocus type='submit'>
                Create
              </Button>
            </DialogActions>
          </Box>
        </DialogContent>
      </Dialog>
    </>
  );
}
