import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import NavbarComponent from '../../components/NavbarComponent';
import IconButton from '@mui/material/IconButton';
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import { APIService } from '../../helpers/APIService';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getClickedBlogPost } from '../../store/actionCreators/blogPostCreator';
import Container from '@mui/material/Container';
import EditBlogPostModal from '../../components/modals/EditBlogPostModal';
import Authentication from '../../helpers/Authentication';
import { Box, Menu, useMediaQuery, useTheme } from '@material-ui/core';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { MenuItem } from '@mui/material';

export default function DetailedBlogPostPage() {
  const [open, setOpen] = React.useState(false);
  const theme = useTheme();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { blogPost } = useTypedSelector((state) => state.blogPosts);
  const blogPostId: any = useLocation().state;
  const isLoggedIn = Authentication.getUser().id != 'null' ? true : false;
  const isMobile = useMediaQuery(theme.breakpoints.down('xl'));
  const [anchor, setAnchor] = React.useState(null);

  React.useEffect(() => {
    dispatch(getClickedBlogPost(blogPostId));
    blogPost.content;
  }, [dispatch]);

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

  const handleMenu = (event: any) => {
    setAnchor(event.currentTarget);
  };

  const DisplayMore = () => {
    if (isMobile) return <></>;
    return (
      <>
        <CardActions>
          <IconButton onClick={handleClickOpen} sx={{ padding: '0' }}>
            <ModeEditOutlineOutlinedIcon color='primary' />
          </IconButton>
          <IconButton onClick={deleteBlogPost} sx={{ padding: '0' }}>
            <DeleteOutlinedIcon color='error' />
          </IconButton>
        </CardActions>
        <EditBlogPostModal
          handleclose={handleClose}
          open={open}
          blogPost={blogPost}
        />
      </>
    );
  };

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        sx={{
          display: 'flex',
          justifyContent: 'center',
        }}
        maxWidth='xl'
      >
        <Grid container>
          <Card
            sx={{
              boxShadow: 'none',
              borderRadius: '0',
            }}
          >
            <Box
              style={{
                backgroundImage: `url(${blogPost.imageSrc})`,
                display: 'flex',
                alignItems: 'flex-end',
                justifyContent: 'flex-end',
              }}
              height='280px'
            >
              {isMobile && (
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
                    <MenuItem onClick={() => setAnchor(null)}>
                      <Typography
                        sx={{ display: 'flex', alignItems: 'center' }}
                      >
                        <ModeEditOutlineOutlinedIcon
                          color='primary'
                          sx={{ marginRight: '7px' }}
                        />{' '}
                        Edit
                      </Typography>
                    </MenuItem>
                  </Menu>
                </Box>
              )}
            </Box>
            <CardContent>
              <CardActions
                sx={{
                  display: 'flex',
                  justifyContent: 'space-between',
                  alignItems: 'baseline',
                }}
              >
                <Typography
                  gutterBottom
                  variant='h5'
                  component='div'
                  sx={{ display: 'flex', justifyContent: 'center' }}
                >
                  {blogPost.header}
                </Typography>

                {isLoggedIn && <DisplayMore />}
              </CardActions>

              <Typography
                variant='body2'
                color='text.secondary'
                sx={{ whiteSpace: 'pre-line' }}
              >
                {blogPost.content}
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </Container>
    </>
  );
}
