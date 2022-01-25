import React from 'react';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import { Box, TextField } from '@material-ui/core';
import AddCircleOutlineRoundedIcon from '@mui/icons-material/AddCircleOutlineRounded';
import TitleRoundedIcon from '@mui/icons-material/TitleRounded';
import { styled } from '@mui/material/styles';
import IStorageBlogPosts from '../interfaces/IStorageBlogPosts';

interface Prop {
  selectedFile: Function;
  image: string;
  blogPost: IStorageBlogPosts;
}

export default function BlogPostContent({
  selectedFile,
  image,
  blogPost,
}: Prop) {
  const Input = styled('input')({
    display: 'none',
  });

  return (
    <>
      <label htmlFor='contained-button-file'>
        <Input
          accept='image/*'
          id='contained-button-file'
          multiple
          type='file'
          name='image'
          onChange={(e: React.ChangeEvent<HTMLInputElement>): void => selectedFile(e)}
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
          alt={blogPost.imageName}
        />
      </Card>
      <Box sx={{ display: 'flex', alignItems: 'flex-end' }}>
        <TitleRoundedIcon
          sx={{ color: 'action.active', mr: 1, my: 3 }}
          fontSize='large'
        />
        <TextField
          margin='normal'
          defaultValue={blogPost.header}
          required
          fullWidth
          id='header'
          label='Title'
          name='header'
          autoComplete='header'
          inputProps={{ maxLength: 56 }}
          helperText='Can max be 56 characters in length'
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
          defaultValue={blogPost.content}
        />
      </Box>
    </>
  );
}
