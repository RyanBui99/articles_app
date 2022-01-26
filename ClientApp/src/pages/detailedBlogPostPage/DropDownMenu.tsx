import React, { useState } from 'react';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import EditBlogPostModal from '../../components/modals/EditBlogPostModal';
import { Box, Menu } from '@material-ui/core';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { MenuItem } from '@mui/material';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import { APIService } from '../../helpers/APIService';
import { useNavigate } from 'react-router-dom';

interface Prop {
    blogPostId: string,
    blogPost: IStorageBlogPosts
}

export default function DropDownMenu({ blogPostId, blogPost }: Prop) {
  const [anchor, setAnchor] = useState(null);
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();
  
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  const deleteBlogPost = async () => {
    await APIService.deleteBlogPost(blogPostId);
    navigate('/');
  };

  const handleMenu = (event: React.BaseSyntheticEvent) => {
    setAnchor(event.currentTarget);
  };
  return (
    <Box>
      <IconButton
        sx={{ padding: '10px', alignSelf: 'flex-end' }}
        onClick={handleMenu}
      >
        <MoreVertIcon sx={{ color: 'white' }} fontSize='large' />
      </IconButton>
      <Menu
        id='menu-appbar'
        anchorEl={anchor}
        anchorOrigin={{
          vertical: 'top',
          horizontal: 'right',
        }}
        keepMounted
        transformOrigin={{
          vertical: 'top',
          horizontal: 'right',
        }}
        open={Boolean(anchor)}
        onClose={() => setAnchor(null)}
      >
        <MenuItem onClick={handleClickOpen}>
          <Typography sx={{ display: 'flex', alignItems: 'center' }}>
            <ModeEditOutlineOutlinedIcon
              color='primary'
              sx={{ marginRight: '7px' }}
            />
            Edit
          </Typography>
        </MenuItem>

        <MenuItem onClick={deleteBlogPost}>
          <Typography sx={{ display: 'flex', alignItems: 'center' }}>
            <DeleteOutlinedIcon color='error' sx={{ marginRight: '7px' }} />
            Delete
          </Typography>
        </MenuItem>
      </Menu>
      <EditBlogPostModal
        handleclose={handleClose}
        open={open}
        blogPost={blogPost}
      />
    </Box>
  );
}
