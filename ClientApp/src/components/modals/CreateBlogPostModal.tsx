import React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import Card from '@mui/material/Card';
import CloseIcon from '@mui/icons-material/Close';
import useMediaQuery from '@mui/material/useMediaQuery';
import CardMedia from '@mui/material/CardMedia';
import { useTheme } from '@mui/material/styles';
import { Box, TextField, IconButton, DialogTitle } from '@material-ui/core';
import AddCircleOutlineRoundedIcon from '@mui/icons-material/AddCircleOutlineRounded';
import TitleRoundedIcon from '@mui/icons-material/TitleRounded';
import SnackbarComponent from '../SnackbarComponent';
import { useDispatch } from 'react-redux';
import { styled } from '@mui/material/styles';
import { ICreateBlogPost } from '../../interfaces/ICreateBlogPost';
import { createNewPost } from '../../store/actionCreators/blogPostCreator';

export default function CreateBlogPostModal(props: any) {
  const Input = styled('input')({
    display: 'none',
  });
  const theme = useTheme();
  const dispatch = useDispatch();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = React.useState('');
  const [severity, setSeverity] = React.useState('success');
  const [imageToServer, setImageToServer] = React.useState<File>();
  const [image, setImage] = React.useState('');

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
    console.log(e.target.files[0])
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
            <label htmlFor='contained-button-file'>
              <Input
                accept='image/*'
                id='contained-button-file'
                multiple
                type='file'
                name='image'
                onChange={selectedFile}
              />
              <Button variant='contained' component='span'>
                Upload
              </Button>
            </label>

            <Card>
              <CardMedia
                component='img'
                height='140'
                image={image}
                alt='green iguana'
              />
            </Card>
            <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
              <TitleRoundedIcon
                sx={{ color: 'action.active', mr: 1, my: 3 }}
                fontSize='large'
              />
              <TextField
                margin='normal'
                required
                fullWidth
                id='header'
                label='Title'
                name='header'
                autoComplete='header'
                inputProps={{ maxLength: 56 }}
                helperText='Can max be 55 characters in length'
                // inputProps={{ style: { fontSize: 40 } }}
                // InputLabelProps={{ style: { fontSize: 40 } }}
              />
            </Box>

            <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
              <AddCircleOutlineRoundedIcon
                sx={{ color: 'action.active', mr: 1, my: 0.9 }}
                fontSize='large'
              />
              <TextField
                margin='normal'
                required
                fullWidth
                multiline
                id='content'
                label='Tell us your story...'
                name='content'
                autoComplete='content'
                autoFocus
              />
            </Box>
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
